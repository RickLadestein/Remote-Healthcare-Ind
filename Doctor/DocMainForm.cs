using System;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Doctor.Network;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Doctor.Profiles;

namespace Doctor
{
    public partial class AstrandDoctorGUI : Form, ConnectionResponseListener
    {
        private Doctor curDoc = null;
        private Patient curPat = null;

        public readonly String hostname = "localhost";
        public readonly int port = 25565;

        private List<BikeMeasurement> c_m;

        private Socket socket;

        public AstrandDoctorGUI()
        {
            this.Visible = false;
            InitializeComponent();
            c_m = new List<BikeMeasurement>();
            if (!BeginConnect())
            {
                MessageBox.Show("Could not connect to server: Stopping application");
                Environment.Exit(0);
            } else
            {
                RunLoginProcedure();

                this.chartSelectedRun.Series = new LiveCharts.SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Heartrate",
                        Values = new ChartValues<double>{ }
                    },
                    new LineSeries
                    {
                        Title = "RPM",
                        Values = new ChartValues<double>{ }
                    },
                    new LineSeries
                    {
                        Title = "Power",
                        Values = new ChartValues<double>{ }
                    }
                };
            }
        }

        private void BtnAppExit_Click(object sender, EventArgs e)
        {
            socket.Stop();
            Application.Exit();
        }

        private void AstrandDoctorGUI_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void lbxPrevTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRouter.GetInstance().SendMessage(this.socket,
                Datapackages.Message_GetFile(this.curDoc.id, "resources\\data", $"{this.curPat.hash}-{(string)lbxPrevTests.SelectedItem}"),
                "file/get", this, true);
        }

        private void onDataFileReceived(List<BikeMeasurement> contents)
        {
            this.chartSelectedRun.Series[0].Values.Clear();
            this.chartSelectedRun.Series[1].Values.Clear();
            this.chartSelectedRun.Series[2].Values.Clear();
            c_m.Clear();
            c_m.AddRange(contents);

            CalculateData();
            foreach (BikeMeasurement b in contents)
            {
                this.chartSelectedRun.Series[0].Values.Add((double)b.Bpm);
                this.chartSelectedRun.Series[1].Values.Add((double)b.Rpm);
                this.chartSelectedRun.Series[2].Values.Add((double)b.Resistance);
            }
        }

        private void CalculateData()
        {
            double avg_hr = 0.0;
            double avg_rs = 0.0;
            double avg_rpm = 0.0;
            foreach (BikeMeasurement b in c_m)
            {
                avg_hr += b.Bpm;
                avg_rs += b.Rpm;
                avg_rpm += b.Rpm;
            }

            avg_hr /= c_m.Count;
            avg_rs /= c_m.Count;
            avg_rpm /= c_m.Count;

            this.label1.Text = $"VO2max: {CalculateVO2(this.curPat, avg_hr)} ml/kg/min";
            this.label2.Text = $"Average Heartrate: {avg_hr} bpm";
            this.label3.Text = $"Average Rpm: {avg_rpm} rom";
            this.label4.Text = $"Steady State Reached: " + (c_m.Count > 9 ? "No" : "Yes");
        }

        private double CalculateVO2(Patient p, double hr)
        {
            double time = c_m.Count > 8 ? 4 : 2;
            if (!p.gender)
            {
                return (100.5 - (0.1636 * p.weight) - (1.438 * time) - (0.1928 * hr));
            } else
            {
                return (108.844 - (0.1636 * p.weight) - (1.438 * time) - (0.1928 * hr));
            }
        }

            private void btnLogout_Click(object sender, EventArgs e)
        {
            DataRouter.GetInstance().SendMessage(this.socket, Datapackages.Message_Logout(curDoc.id.ToString()), "user/logout", this, true);
        }

        private void btnChangePatient_Click(object sender, EventArgs e)
        {
            using (DocPatientSelect showTest = new DocPatientSelect(socket, curDoc))
            {
                showTest.ShowDialog();
                if(showTest.GetSelectedPatient() != null)
                    SetPatient(showTest.GetSelectedPatient());
            }
        }

        private void btnNewRun_Click(object sender, EventArgs e)
        {
            if (this.curPat == null) {
                MessageBox.Show("Could not start test: no patient selected");
                return;
            }
            Form runForm = new DocNewRunForm(curDoc, curPat, socket);
            runForm.ShowDialog();

            DataRouter.GetInstance().setGenericMessageListener(this);
            DataRouter.GetInstance().SendMessage(this.socket, Datapackages.Message_GetFilenames(this.curDoc.id, "resources\\data", this.curPat.hash), "file/getnames", this, true);
            // TODO: Add new run to the list

            lbxPrevTests.SelectedIndex = 0;
        }

        private void SetPatient(Patient newPat)
        {
            this.curPat = newPat;

            lblPatName.Text = "Name: " + newPat.first_name + " " + newPat.sur_name;
            lblPatGender.Text = "Gender: " + (newPat.gender ? "Male" : "Female");

            int age = newPat.getAge();
            if (newPat.birthday.Date > DateTime.Today.AddYears(-age)) age--;

            lblPatBirthday.Text = "Date of Birth: " + newPat.birthday.Date.ToShortDateString() + " (" + age + ")";
            DataRouter.GetInstance().SendMessage(this.socket, Datapackages.Message_GetFilenames(this.curDoc.id, "resources\\data", this.curPat.hash), "file/getnames", this, true);
        }

        private void RunLoginProcedure()
        {
            if (this.Visible)
            {
                this.Visible = false;
                // Clear all while invisible

                curPat = null;
                lblPatBirthday.Text = "Date of Birth: ";
                lblPatGender.Text = "Gender: ";
                lblPatName.Text = "Name: ";
                lbxPrevTests.Items.Clear();
                chartSelectedRun.Series.Clear();

            }
            //Get new data
            Doctor newDoc;

            using (DocLoginForm login = new DocLoginForm(this.socket))
            {
                login.ShowDialog();

                newDoc = login.GetDoctor();
            }

            this.curDoc = newDoc;

            if(curDoc == null)
                System.Environment.Exit(-1);

            lblUsername.Text = "Username: " + curDoc.username;
            this.Visible = true;
        }

        private void chartSelectedRun_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private bool BeginConnect()
        {
            int tries = 0;

            socket = new Socket(hostname, port);
            socket.onMessageReceived = DataRouter.GetInstance().OnMessageReceivedDelegate;
            socket.onSocketError = OnSocketError;

            while(!socket.GetConnected())
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

        public void OnSocketError(Socket s, String message) 
        {
            MessageBox.Show(message);
        }

        public void onMessageResponse(string command, dynamic data)
        {
            if(command == "user/logout")
            {
                this.curDoc = new Doctor("", Guid.Empty);
                BeginInvoke((Action)(() => RunLoginProcedure()));
            } else if(command == "file/getnames")
            {
                List<String> files = ((JArray)data.data).ToObject<List<String>>();
                BeginInvoke((Action)(() => lbxPrevTests.Items.Clear()));
                foreach (String s in files)
                    BeginInvoke((Action)(() => lbxPrevTests.Items.Add(s.Substring(33, (s.Length - 33)))));
            } else if(command == "file/get")
            {
                String measurement = (String)data.data;
                List<BikeMeasurement> ms = ((JArray)Newtonsoft.Json.JsonConvert.DeserializeObject(measurement)).ToObject<List<BikeMeasurement>>();
                BeginInvoke((Action)(() => this.onDataFileReceived(ms)));
            }
        }

        public void onMessageResponseError(string command, string info)
        {
            throw new NotImplementedException();
        }

        public void onGenericMessageReceived(string command, dynamic data)
        {
            //throw new NotImplementedException();
        }
    }
}
