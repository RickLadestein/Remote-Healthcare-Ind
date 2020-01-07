using Doctor.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Doctor
{
    public partial class DocPatientSelect : Form, ConnectionResponseListener
    {
        private Doctor curDoc;
        private Socket socket;
        private Patient SelectedPatient { get; set; }

        public DocPatientSelect()
        {
            InitializeComponent();
            MessageBox.Show("Something went wrong. Please contact your system administrator!\nError code: ERR_NO_DOCNAME");
        }
        public DocPatientSelect(Socket s, Doctor doctor)
        {
            InitializeComponent();
            this.socket = s;
            PollData();
            btnSelectPatient.Enabled = false;
            btnEditPatient.Enabled = false;

            curDoc = doctor;
        }

        public Patient GetSelectedPatient()
        {
            return SelectedPatient;
        }

        private void BtnNewPatient_Click(object sender, EventArgs e)
        {
            Form np = new DocNewPatientForm(this.socket, this.curDoc);
            np.ShowDialog();
            PollData();
        }

        private void BtnEditPatient_Click(object sender, EventArgs e)
        {
            Form ep = new DocEditPatientForm(this.curDoc, (Patient)this.cbxPatientSelect.SelectedItem, this.socket);
            ep.ShowDialog();
            PollData();
            // TODO: Update Patient
        }

        private void CbxPatientSelect_TextChanged(object sender, EventArgs e)
        {
            // Does not trigger correctly, using SelectedIndexChanged(...) instead
        }

        private void BtnSelectPatient_Click(object sender, EventArgs e)
        {
            if (cbxPatientSelect.SelectedIndex >= 0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a patient");
            }
        }

        private void cbxPatientSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Patient p = (Patient)cbxPatientSelect.SelectedItem;
            SelectedPatient = p;
            lblDetailsName.Text = $"Name: {p.first_name} {p.sur_name}";
            lblDetailsGender.Text = p.gender ? "Gender: Male" : "Gender: Female";
            lblDetailsDate.Text = $"Age: {p.getAge()}";
            
            btnSelectPatient.Enabled = true;
            btnEditPatient.Enabled = true;
        }

        private void PollData()
        {
            DataRouter.GetInstance().SendMessage(this.socket, Datapackages.Message_GetPatientsUID(), "patients/get_online", this, true);
        }

        private void DocPatientSelect_FormClosed(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        public void onMessageResponse(string command, dynamic data)
        {
            if(command == "patients/get_online")
            {
                List<Patient> users = ((JArray)data.data).ToObject<List<Patient>>();
                BeginInvoke((Action)(() => cbxPatientSelect.Items.Clear()));
                foreach (Patient u in users)
                    BeginInvoke((Action)(() => cbxPatientSelect.Items.Add(u)));
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
