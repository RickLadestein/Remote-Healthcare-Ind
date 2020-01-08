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
using System.Timers;
using System.Diagnostics;
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

        private int textChangeCooldown;
        private System.Timers.Timer textChangeCooldownTimer;

        private BikeMeasurement prevMeasurement;
        private BikeMeasurement newestMeasurement;

        private System.Timers.Timer timer;
        private List<BikeMeasurement> measurements;
        private int elapsedSeconds;
        private bool testRunning;

        private String bound_doc = "";
        
        private bool steadyStateReached;
        private int[] steadyStateHeartrates;


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

            lblInstruction.Text = "Please wait for the doctor to start the test.";
            lblInstruction.Location = new System.Drawing.Point((this.Size.Width - lblInstruction.Size.Width) / 2, lblInstruction.Location.Y);

            textChangeCooldown = 0;
            textChangeCooldownTimer = new System.Timers.Timer(1000);
            textChangeCooldownTimer.Elapsed += OnTextChangeCooldownTimerTick;
            textChangeCooldownTimer.Start();

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimerTick;
            testRunning = false;
            steadyStateReached = false;

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
            //SetInstructionText(Instruction.START_READING);

            RunTest();
        }

        private void SetInstructionText(Instruction instruction)
        {

            if (!testRunning)
                return;

            string oldMessage = lblInstruction.Text;
            string newMessage;


            switch(instruction)
            {
                case Instruction.WAIT_START:
                    newMessage = "Please wait for the doctor to start the test.\nThe test consists of 3 parts: \n2 minutes of warming up, 2-4 minutes of testing and 1 minute cooling down.";
                    //lblInstruction.Text = "Please wait for the doctor to start the test.";
                    break;
                case Instruction.WAIT_END:
                    newMessage = "The test has been completed. Please wait for the doctor for further instructions.";
                    break;
                case Instruction.START_WARMUP:
                    newMessage = "The warmup phase has begun. \nPlease try to stay between 50 to 60 rotations per minute.";
                    break;
                case Instruction.START_READING:
                    newMessage = "The reading phase has begun. The bike will adjust power for the optimal resistance. \nPlease try to stay between 50 and 60 rotations per minute.";
                    break;
                case Instruction.START_COOLDOWN:
                    newMessage = "The cooldown phase has begun.";
                    break;
                case Instruction.PEDDLE_SLOWER:
                    newMessage = "Please slow down. \nStay between 50 to 60 rotations per minute.";
                    break;
                case Instruction.PEDDLE_FASTER:
                    newMessage = "Please speed up. \nStay between 50 to 60 rotations per minute.";
                    break;
                case Instruction.PEDDLE_RIGHT:
                    newMessage = "Stay between 50 to 60 rotations per minute.";
                    break;
                case Instruction.HEARTRATE_STEADY:
                    newMessage = "A steady state has been reached. Please keep cycling.";
                    break;
                default:
                    newMessage = "";
                    break;
            }

            if (oldMessage != newMessage)
            {
                this.BeginInvoke((Action)(() => lblInstruction.Text = newMessage));
                this.BeginInvoke((Action)(() => lblInstruction.Location = new System.Drawing.Point((this.Size.Width - lblInstruction.Size.Width) / 2, lblInstruction.Location.Y)));
                textChangeCooldown = 5;
            }
        }

        public void OnMeasurementReceived(BikeMeasurement measurement)
        {
            newestMeasurement = measurement;

            this.BeginInvoke((Action)(() => sgHeartRate.Value = measurement.Bpm));
            this.BeginInvoke((Action)(() => sgPower.Value = measurement.Resistance));
            this.BeginInvoke((Action)(() => sgRpm.Value = measurement.Rpm));

            if(textChangeCooldown < 1 && testRunning)
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
            String msg = (String)message.msg;
            switch(msg)
            {
                case "FIRST MESSAGE":
                    break;
                case "START":
                    BeginInvoke((Action)(() => RunTest()));
                    break;
                case "STOP":
                    if(testRunning)
                        BeginInvoke((Action)(() => EndTest(false)));
                    break;
            }
        }
        #endregion

        private void PatGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            BikeHandler.GetInstance().ClosePort();
            this.socket.Stop();
        }

        private void RunTest()
        {
            elapsedSeconds = 0;
            measurements = new List<BikeMeasurement>();
            SetInstructionText(Instruction.START_WARMUP);
            lblCounter.Visible = true;
            steadyStateReached = false;
            steadyStateHeartrates = new int[5];
            testRunning = true;

            BikeHandler.GetInstance().SetBikeSettings(125, new TimeSpan(0, 7, 0));
            //BikeHandler.GetInstance().
            //BikeHandler.GetInstance().SetPower(75);

            //this.elapsedSeconds = 100;
            timer.Start();
            
        }

        private void EndTest(bool completed)
        {
            if (completed)
                DataRouter.GetInstance().SendMessage(this.socket, Datapackages.Message_Message(this.curPat.id.ToString(), this.bound_doc, "END"),
                    "user/msg", this, false);

            timer.Stop();
            testRunning = false;
            SetInstructionText(Instruction.WAIT_END);
            this.BeginInvoke((Action)(() => lblCounter.Visible = false));
            this.bound_doc = "";
            SaveData();
        }

        private void SaveData()
        {
            DateTime now = DateTime.Now;
            DataRouter.GetInstance().SendMessage(this.socket, Datapackages.Message_CreateFile(this.curPat.id, "resources\\data",
                $"{curPat.hash}-{now.Year}-{now.Month}-{now.Day}-{now.Hour}{now.Minute}.json", this.measurements), "file/create", this, true);
        }

        private void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            this.BeginInvoke((Action)(() => pgbProgress.Increment(1)));
            elapsedSeconds++;

            int countdown = 420 - elapsedSeconds;
            double mins = Math.Floor(countdown / 60d);
            this.BeginInvoke((Action)(() => lblCounter.Text = mins + ":" + (countdown - mins*60)));
            
            //
            // WARMING UP
            // MIN. 1-2
            //
            if(elapsedSeconds < 120)
            {
                Debug.WriteLine("In Warming Up: " + elapsedSeconds);
            }

            //
            // MEASURING
            // MIN. 3-6
            //
            if(elapsedSeconds >= 120 && elapsedSeconds <= 360)
            {
                Debug.WriteLine("In Measuring: " + elapsedSeconds);
                
                if(elapsedSeconds == 180 || elapsedSeconds == 240)
                {
                    Debug.WriteLine("Adding measurement to list first two minutes");
                    // Eerste twee minuten iedere minuut
                    measurements.Add(newestMeasurement);
                }
            
                if(elapsedSeconds > 240 && elapsedSeconds % 15 == 0)
                {
                    Debug.WriteLine("Adding measurement to list last two minutes");
                    measurements.Add(newestMeasurement);
                    // Daarna iedere 15 secs
                }

                if(elapsedSeconds % 5 == 0)
                {
                    Debug.WriteLine("Adjusting resistance");


                    // Resistance aanpassen
                    if (newestMeasurement.Bpm < 130)
                    {
                        Debug.WriteLine("Adjusting resistance up");

                        BikeHandler.GetInstance().AddPower("25");
                    }
                    else if(newestMeasurement.Bpm > 200)
                    {
                        Debug.WriteLine("Adjusting resistance down");

                        BikeHandler.GetInstance().AddPower("-25");
                    }

                    
                    if(!steadyStateReached && CheckSteadyState(newestMeasurement))
                    {
                        SetInstructionText(Instruction.HEARTRATE_STEADY);
                        steadyStateReached = true;
                        elapsedSeconds = 239;

                        measurements.Clear();

                        this.BeginInvoke((Action)(() => pgbProgress.Value = 240));
                    }

                    prevMeasurement = newestMeasurement;

                    Debug.WriteLine("Checked SteadyState: " + steadyStateReached);

                }
            }

            //
            // COOLING DOWN
            // MIN. 7
            //
            if(elapsedSeconds > 360)
            {
                Debug.WriteLine("In Cooldown: " + elapsedSeconds);
                if (newestMeasurement.Resistance != 75)
                    BikeHandler.GetInstance().SetPower(75);
            }

            //
            // TEST END
            //
            if(elapsedSeconds > 420)
            {
                Debug.WriteLine("Time to end the test.:. " + elapsedSeconds);

                EndTest(true);
            }

        }

        private bool CheckSteadyState(BikeMeasurement newMes)
        {
            if (prevMeasurement == null)
                return false;

            return Math.Abs(newMes.Bpm - prevMeasurement.Bpm) < 5 && newMes.Bpm >= 130;
        }

        private void OnTextChangeCooldownTimerTick(object sender, ElapsedEventArgs e)
        {
            textChangeCooldown--;
        }
    }
}
