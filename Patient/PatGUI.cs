using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patient.Bike;
using Patient.Communication;
using System.Threading;

namespace Patient
{
    public partial class PatGUI : Form, ConnectionResponseListener, Bike.IBikeMeasurementListener
    {
        private readonly String hostname = "localhost";
        private readonly int port = 25565;

        private Socket socket;
        private BikeHandler bh;
        private Patient curPat;
        private List<BikeMeasurement> measurements;
        private bool testRunning;

        private String bound_doc = "";
        

        public PatGUI()
        {
            InitializeComponent();
            if(!BeginConnect())
            {
                MessageBox.Show("Could not connect to server: Stopping application");
                Environment.Exit(0);
            }
            StartLogin();

            lblCounter.Visible = false;
            //SetInstructionText(Instruction.WAIT_START);

            sgRpm.To = 120;
            sgPower.To = 400;
            sgHeartRate.To = 200;

            testRunning = true;

            bh = BikeHandler.GetInstance();
            bh.AddSubscriber(this);
            bh.StartTimer();
        }

        private void StartLogin()
        {
            PatPatientSelect patientselect = new PatPatientSelect(socket);
            patientselect.ShowDialog();
            this.curPat = patientselect.GetPatient();

            if(this.curPat == null)
            {
                Environment.Exit(0);
            }
            DataRouter.GetInstance().setGenericMessageListener(this);
        }

        private bool BeginConnect()
        {
            int tries = 0;
            socket = new Socket(hostname, port);
            socket.onMessageReceived = DataRouter.GetInstance().OnMessageReceivedDelegate;
            socket.onSocketError = onConnectionError;

            while (!socket.GetConnected())
            {
                Thread.Sleep(1000);
                tries += 1;

                if (tries == 10)
                {
                    return false;
                }
            }
            socket.Start();
            return true;
        }

        

        private void DummyButton_Click(object sender, EventArgs e)
        {
            //DataRouter.GetInstance().SendMessage(c, Datapackages.Message_GetFilenames(new Guid(), "resources//data", "txt"), "file/getnames", this, true);
            SetInstructionText(Instruction.START_READING);

            bh.StartTimer();
        }

        private void SetInstructionText(Instruction instruction)
        {
            switch(instruction)
            {
                case Instruction.WAIT_START:
                    this.BeginInvoke((Action)(() => lblInstruction.Text = "Please wait for the doctor to start the test."));
                    //lblInstruction.Text = "Please wait for the doctor to start the test.";
                    break;
                case Instruction.WAIT_END:
                    this.BeginInvoke((Action)(() => lblInstruction.Text = "The test has been completed. Please wait for the doctor for further instructions."));
                    break;
                case Instruction.START_WARMUP:
                    this.BeginInvoke((Action)(() => lblInstruction.Text = "The warmup phase has begun. Please try to stay between 50 to 60 rotations per minute."));
                    break;
                case Instruction.START_READING:
                    this.BeginInvoke((Action)(() => lblInstruction.Text = "The reading phase has begun. The bike will adjust power for the optimal resistance. \nPlease try to stay between 50 and 60 rotations per minute."));
                    break;
                case Instruction.START_COOLDOWN:
                    this.BeginInvoke((Action)(() => lblInstruction.Text = "The cooldown phase has begun."));
                    break;
                case Instruction.PEDDLE_SLOWER:
                    this.BeginInvoke((Action)(() => lblInstruction.Text = "Please slow down. \nStay between 50 to 60 rotations per minute."));
                    break;
                case Instruction.PEDDLE_FASTER:
                    this.BeginInvoke((Action)(() => lblInstruction.Text = "Please speed up. \nStay between 50 to 60 rotations per minute."));
                    break;
                case Instruction.PEDDLE_RIGHT:
                    this.BeginInvoke((Action)(() => lblInstruction.Text = "Stay between 50 to 60 rotations per minute."));
                    break;
                case Instruction.HEARTRATE_STEADY:
                    this.BeginInvoke((Action)(() => lblInstruction.Text = "A steady state has been reached. Please keep cycling."));
                    break;
                default:
                    this.BeginInvoke((Action)(() => lblInstruction.Text = ""));
                    break;
            }

            //lblInstruction.Location = new System.Drawing.Point((this.Size.Width - lblInstruction.Size.Width) / 2, lblInstruction.Location.Y);
            this.BeginInvoke((Action)(() => lblInstruction.Location = new System.Drawing.Point((this.Size.Width - lblInstruction.Size.Width) / 2, lblInstruction.Location.Y)));

        }

        public void OnMeasurementReceived(BikeMeasurement measurement)
        {
            this.BeginInvoke((Action)(() => sgHeartRate.Value = measurement.Bpm));
            this.BeginInvoke((Action)(() => sgPower.Value = measurement.Resistance));
            this.BeginInvoke((Action)(() => sgRpm.Value = measurement.Rpm));

            if (measurement.Rpm > 63)
                SetInstructionText(Instruction.PEDDLE_SLOWER);
            else if (measurement.Rpm < 47)
                SetInstructionText(Instruction.PEDDLE_FASTER);
            else
                SetInstructionText(Instruction.PEDDLE_RIGHT);

            if (bound_doc != "")
            {
                DataRouter.GetInstance().SendMessage(
                    this.socket,
                    Datapackages.Message_TrainingData(this.curPat.id, this.bound_doc, measurement),
                    "user/data",
                    this,
                    false);
            }


            if(testRunning)
            {
                //measurements.Add(measurement);
            }

        }

        #region Callbacks
        public void onConnectionError(Socket c, String e)
        {
            Console.WriteLine("[Patient]: " + e);
        }

        public void onMessageResponse(string command, object data)
        {
        }

        public void onMessageResponseError(string command, string info)
        {
            Console.WriteLine("Hi something went wrong here");
        }

        public void onGenericMessageReceived(string command, dynamic data)
        {
            dynamic message = data.data.data;
            this.bound_doc = (string) message.id;        
        }
        #endregion

        private void PatGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            BikeHandler.GetInstance().ClosePort();
            this.socket.Stop();
        }
    }
}
