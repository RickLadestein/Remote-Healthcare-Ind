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

namespace Patient
{
    public partial class PatGUI : Form, ConnectionResponseListener, Bike.IBikeMeasurementListener
    {
        private Socket s;
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
        private bool steadyStateReached;
        private int[] steadyStateHeartrates;


        public PatGUI()
        {
            InitializeComponent();
            //StartConnection();
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
            //SetInstructionText(Instruction.START_READING);

            RunTest();
        }

        private void SetInstructionText(Instruction instruction)
        {
            string oldMessage = lblInstruction.Text;
            string newMessage;

            switch(instruction)
            {
                case Instruction.WAIT_START:
                    newMessage = "Please wait for the doctor to start the test.";
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

            if(textChangeCooldown < 1)
                if (measurement.Rpm > 63)
                    SetInstructionText(Instruction.PEDDLE_SLOWER);
                else if (measurement.Rpm < 47)
                    SetInstructionText(Instruction.PEDDLE_FASTER);
                else
                    SetInstructionText(Instruction.PEDDLE_RIGHT);


            if(testRunning)
            {
                DataRouter.GetInstance().SendMessage(s, Datapackages.Message_TrainingData(curPat.id, "", measurement), "user/data", this, false);
                //measurements.Add(measurement);
            }

        }

        public void onGenericMessageReceived(string command, dynamic data)
        {
            throw new NotImplementedException();
            // Start test
            if(false) // Test start msg
            {
                RunTest();
            }
            // End test? send it?
        }

        private void RunTest()
        {
            elapsedSeconds = 0;
            measurements = new List<BikeMeasurement>();
            SetInstructionText(Instruction.START_WARMUP);
            lblCounter.Visible = true;
            steadyStateReached = false;
            steadyStateHeartrates = new int[5];

            BikeHandler.GetInstance().SetBikeSettings(50, new TimeSpan(0, 7, 0));
            //BikeHandler.GetInstance().
            //BikeHandler.GetInstance().SetPower(75);

            elapsedSeconds = 100;

            timer.Start();
            
        }

        private void EndTest()
        {
            timer.Stop();

            SetInstructionText(Instruction.WAIT_END);
            this.BeginInvoke((Action)(() => lblCounter.Visible = false));
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

                        BikeHandler.GetInstance().AddPower("50");
                    }
                    else if(newestMeasurement.Bpm > 200)
                    {
                        Debug.WriteLine("Adjusting resistance down");

                        BikeHandler.GetInstance().AddPower("-50");
                    }

                    
                    if(!steadyStateReached && CheckSteadyState(newestMeasurement))
                    {
                        SetInstructionText(Instruction.HEARTRATE_STEADY);
                        steadyStateReached = true;
                        elapsedSeconds = 240;
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

                EndTest();
            }

        }

        private bool CheckSteadyState(BikeMeasurement newMes)
        {
            if (prevMeasurement == null)
                return false;

            return Math.Abs(newMes.Bpm - prevMeasurement.Bpm) < 5; 



            for (int i = 1; i < 5; i++)
                steadyStateHeartrates[i] = steadyStateHeartrates[i - 1];

            steadyStateHeartrates[0] = newMes.Bpm;

            bool ss = true;

            for (int i = 1; i < 5; i++)
                if (Math.Abs(steadyStateHeartrates[i] - steadyStateHeartrates[0]) > 5)
                    ss = false;

            return ss;
        }

        private void OnTextChangeCooldownTimerTick(object sender, ElapsedEventArgs e)
        {
            textChangeCooldown--;
        }
    }
}
