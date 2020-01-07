using System;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Doctor.Network;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Doctor
{
    public partial class AstrandDoctorGUI : Form, ConnectionResponseListener
    {
        Doctor curDoc;
        Patient curPat;

        public readonly String hostname = "localhost";
        public readonly int port = 25565;

        private Socket socket;

        public AstrandDoctorGUI()
        {
            this.Visible = false;
            InitializeComponent();
            if (!BeginConnect())
            {
                MessageBox.Show("Could not connect to server: Stopping application");
                Application.Exit();
                this.Close();
            } else
            {
                RunLoginProcedure();
            }
            

            // TODO
            //curDoc = doctor;
            //this.owner = owner;
            ////curPat = patient;

            //lblUsername.Text = "Username: " + curDoc.username;
        }

        private void BtnAppExit_Click(object sender, EventArgs e)
        {
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

        private void onDataFileReceived(String contents)
        {

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

                SetPatient(showTest.GetSelectedPatient());
            }
        }

        private void btnGearUp_Click(object sender, EventArgs e)
        {
            // TODO
        } // TODO

        private void btnGearDown_Click(object sender, EventArgs e)
        {
            // TODO
        } // TODO

        private void btnNewRun_Click(object sender, EventArgs e)
        {
            Form runForm = new DocNewRunForm(curDoc, curPat);
            runForm.ShowDialog();

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
                string file = (string)data.data;
                BeginInvoke((Action)(() => this.onDataFileReceived(file)));
                //String file = (String) data.data;
            }
        }

        public void onMessageResponseError(string command, string info)
        {
            throw new NotImplementedException();
        }

        public void onGenericMessageReceived(string command, dynamic data)
        {
            throw new NotImplementedException();
        }
    }
}
