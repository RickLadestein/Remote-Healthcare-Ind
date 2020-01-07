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

namespace Patient
{
    public partial class PatGUI : Form, ConnectionResponseListener, Bike.IBikeMeasurementListener
    {
        private Socket s;
        private BikeHandler bh;
        private Patient curPat;
        private List<BikeMeasurement> measurements;
        private bool testRunning;
        

        public PatGUI()
        {
            InitializeComponent();
            //StartConnection();
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

        private void StartConnection()
        {
            s = new Socket("localhost", 25565);
        }

        public void onConnectionError(Socket c, Exception e)
        {
            Console.WriteLine("[Patient]: " + e.Message);
        }

        public void onDataReceived(Socket c, byte[] data, ushort length)
        {
            String message = Encoding.UTF8.GetString(data);
            DataRouter.GetInstance().OnMessageReceived(c, message);
        }

        public void onMessageResponse(string command, object data)
        {
            Console.WriteLine(data);
        }

        public void onMessageResponseError(string command, string info)
        {
            throw new NotImplementedException();
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


            if(testRunning)
            {
                DataRouter.GetInstance().SendMessage(s, Datapackages.Message_TrainingData(curPat.id, "", measurement), "user/data", this, false);
                measurements.Add(measurement);
            }

        }

        public void onGenericMessageReceived(string command, dynamic data)
        {
            throw new NotImplementedException();
        }
    }
}
