using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Timers;
using System.Globalization;
using System.Management;
using System.Management.Instrumentation;


namespace Patient.Bike
{
    class BikeHandler
    {
        #region Variables
        private const int DATA_SPEED = 9600;
        private string COM_PORT;

        private Timer poller;

        private SerialPort port;
        private string currentmessage;

        public bool alive;
        private int power = 25;

        private List<IBikeMeasurementListener> subscribers;
        #endregion

        #region instances
        private static BikeHandler instance;
        public static BikeHandler GetInstance()
        {
            if (instance == null)
            {
                instance = new BikeHandler();
            }
            return instance;
        }
        #endregion
        private BikeHandler()
        {
            subscribers = new List<IBikeMeasurementListener>();
            Console.WriteLine("--Connecting to bike");
            try
            {
                this.COM_PORT = getComport();
                port = new SerialPort(COM_PORT, DATA_SPEED);
                port.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
                port.Open();
                alive = true;
                Console.WriteLine("--Connected to bike");
            }
            catch (Exception ex)
            {
                Console.WriteLine("--Could not open comport: " + ex);
                //Environment.Exit(-1);
            }
            InitiateTimer();
            SendCommand("RS", "");
        }

        private string getComport()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\cimv2",
                "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                string port = queryObj["Caption"].ToString();
                Console.WriteLine(queryObj["Caption"].ToString());
                if (port.Contains("Silicon Labs CP210x USB to UART Bridge"))
                    return (port.Substring(port.Length - 5, 4));

            }
            return "";
        }

        private void SendCommand(string command, string argument)
        {
            if (alive)
            {
                try
                {
                    port.WriteLine($"{command}{argument}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("--Data could not be sent: " + e);
                    alive = false;
                    ClosePort();
                }
            }
        }

        public void SetBikeSettings(int power, TimeSpan time)
        {
            SendCommand("RS", ""); // reset the bike
            System.Threading.Thread.Sleep(200);
            SendCommand("CM", ""); // enter command mode
            //SendCommand("CD", ""); // enter countdownmode
            SendCommand("PW", $" {power}"); // set the power
            SendCommand("PT", $" {(time.Minutes * 60) + time.Seconds}"); // set the time
            power = 25;
        }

        public void StartTimer()
        {
            poller.Start();
        }

        public void StopTimer()
        {
            poller.Stop();
        }

        public void SetPower(int power)
        {
            SendCommand("PW", $" {power}");
            this.power = power;
        }

        public void AddPower(string increment)
        {
            this.power += int.Parse(increment);
            SetPower(power);
        }

        public void SetTime(TimeSpan time)
        {
            SendCommand("PT", $" {time}");
        }

        public void GetStatus()
        {
            SendCommand("ST", "");
        }

        public void ResetBike()
        {
            SendCommand("RS", "");
        }

        public void AddSubscriber(IBikeMeasurementListener listener)
        {
            if (!subscribers.Contains(listener))
            {
                subscribers.Add(listener);
            }
        }

        public void ClosePort()
        {
            Console.WriteLine("Closing connection to bike");
            try
            {
                poller.Stop();
                port.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not close connection to bike: " + e);
            }
        }

        private void PackData(String data)
        {
            string[] components = data.Split('|');
            int heartbeat = int.Parse(components[0]);
            int rpm = int.Parse(components[1]);
            double speed = double.Parse(components[2]);
            double distance = double.Parse(components[3]);
            int power = int.Parse(components[4]);
            int energy = int.Parse(components[5]);
            TimeSpan time = TimeSpan.ParseExact(components[6], "mm\\:ss", CultureInfo.InvariantCulture);

            BikeMeasurement measurement = new BikeMeasurement(heartbeat, rpm, speed, distance, power, energy, time);

            foreach (IBikeMeasurementListener listener in subscribers)
            {
                listener.OnMeasurementReceived(measurement);
            }
        }

        private void InitiateTimer()
        {
            poller = new Timer(1000);
            poller.Elapsed += OnTimedEvent;
            poller.AutoReset = true;
            poller.Enabled = true;
            poller.Stop();
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            GetStatus();
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int character = port.ReadByte();
            if (character == 13 || character == 10) // if character is CR or LB then send the data to the manager
            {
                if (currentmessage == "ACK" || currentmessage == "RUN" || currentmessage == "ERROR")
                {
                    Console.WriteLine($"|   Bike sent {currentmessage}");
                    currentmessage = "";
                }
                else
                {
                    if (currentmessage != "")
                    {
                        PackData(currentmessage);
                        currentmessage = "";
                    }

                }

            }
            else if (character == 9) // if character is a TAB then record a | in the message
            {
                currentmessage += "|";
            }
            else if (character == 8) // if character is a BKSPC then remove last character from the message
            {
                currentmessage = currentmessage.Remove(currentmessage.Length - 1);
            }
            else // if the character is a normal character then add it to the message
            {
                currentmessage += Convert.ToString(Convert.ToChar(character));
            }
        }
    }
}
