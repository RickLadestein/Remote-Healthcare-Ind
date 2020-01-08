using Newtonsoft.Json.Linq;
using Patient.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient
{
    public partial class PatPatientSelect : Form, ConnectionResponseListener
    {
        private Socket socket;
        private Patient SelectedPatient { get; set; }

        public PatPatientSelect(Socket s)
        {
            InitializeComponent();
            this.socket = s;
            this.SelectedPatient = null;
            PollData();
        }


        private void PollData()
        {
            DataRouter.GetInstance().SendMessage(socket, Datapackages.Message_GetAllPatients(), "patient/get_all", this, true);
        }

        private void PatPatientSelect_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void BtnSelectPatient_Click(object sender, EventArgs e)
        {
            if (cbxPatientSelect.SelectedIndex >= 0)
            {
                this.SelectedPatient = (Patient)cbxPatientSelect.SelectedItem;
                DataRouter.GetInstance().SendMessage(this.socket, Datapackages.Message_Login(this.SelectedPatient.hash), "user/login", this, true);
            }
            else
            {
                MessageBox.Show("Please select a patient");
            }
        }

        public Patient GetPatient()
        {
            return this.SelectedPatient;
        }

        private void cbxPatientSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Patient p = (Patient)cbxPatientSelect.SelectedItem;
            SelectedPatient = p;
            lblDetailsName.Text = $"Name: {p.first_name} {p.sur_name}";
            lblDetailsGender.Text = p.gender ? "Gender: Male" : "Gender: Female";
            lblDetailsDate.Text = $"Age: {p.getAge()}";

            btnSelectPatient.Enabled = true;
        }

        public void onMessageResponse(string command, dynamic data)
        {
            if(command == "patient/get_all")
            {
                List<Patient> users = ((JArray)data.data).ToObject<List<Patient>>();
                BeginInvoke((Action)(() => cbxPatientSelect.Items.Clear()));
                foreach (Patient p in users)
                {
                    BeginInvoke((Action)(() => cbxPatientSelect.Items.Add(p)));
                }
            } else if(command == "user/login")
            {
                this.SelectedPatient.id = new Guid((String)data.info);
                BeginInvoke((Action)(() => this.Close()));
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
