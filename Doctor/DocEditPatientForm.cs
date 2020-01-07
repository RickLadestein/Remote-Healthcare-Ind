using Doctor.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor
{
    public partial class DocEditPatientForm : Form, ConnectionResponseListener
    {
        private Patient current;
        private Doctor d;
        private Socket s;
        public DocEditPatientForm()
        {
            InitializeComponent();
        }
        public DocEditPatientForm(Doctor d, Patient p, Socket s)
        {
            InitializeComponent();
            current = p;
            this.s = s;
            this.d = d;

            this.inpBirth.Value = p.birthday;
            this.inpName.Text = p.first_name;
            this.inpSurName.Text = p.sur_name;
            this.inpWeight.Text = $"{p.weight}";
            this.inpHeight.Text = $"{p.height}";
            this.inpGender.SelectedIndex = p.gender ? 0 : 1;

            // Autofill fields from server

            // Store initial values
            // Put a * next to any edited values
        }

        public void onGenericMessageReceived(string command, dynamic data)
        {
            throw new NotImplementedException();
        }

        public void onMessageResponse(string command, dynamic data)
        {
            if(command == "user/edit")
            {
                BeginInvoke((Action)(() => this.Close()));            
            }
        }

        public void onMessageResponseError(string command, string info)
        {
            throw new NotImplementedException();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                current.birthday = this.inpBirth.Value;
                current.first_name = this.inpName.Text;
                current.sur_name = this.inpSurName.Text;
                current.weight = int.Parse(this.inpWeight.Text);
                current.height = int.Parse(this.inpHeight.Text);
                current.gender = this.inpGender.SelectedIndex == 0 ? true : false;

                DataRouter.GetInstance().SendMessage(this.s, Datapackages.Message_EditPatient(d.id, current), "user/edit", this, true);
            } catch(Exception ex)
            {
                MessageBox.Show("An error occured: Did not save settings");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You have unsaved changes. Are you sure you want to close without saving?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void inpWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void inpHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void inpBirth_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
