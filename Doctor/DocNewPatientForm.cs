using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doctor.Network;

namespace Doctor
{
    public partial class DocNewPatientForm : Form, ConnectionResponseListener
    {
        private Socket socket;
        private Doctor cur_doc;
        public DocNewPatientForm(Socket s, Doctor d)
        {
            InitializeComponent();
            this.socket = s;
            this.cur_doc = d;
            // Check for unfilled fields (inc. date)
            // Check for values that seem off (short name, very young/old age)
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime birthday = this.inpBirth.Value;
                String name = this.inpName.Text;
                String surname = this.inpSurName.Text;
                int weight = int.Parse(this.inpWeight.Text);
                int height = int.Parse(this.inpHeight.Text);
                bool gender = this.inpGender.SelectedIndex == 0 ? true : false;
                Patient p = new Patient(name, surname, birthday, gender, height, weight);
                DataRouter.GetInstance().SendMessage(socket, Datapackages.Message_AddPatient(cur_doc.id, p), "user/add", this, true);
            } catch(Exception ex)
            {
                MessageBox.Show("Oops something went wrong parsing values: try again!");
            }
            
        }

        public void onGenericMessageReceived(string command, dynamic data)
        {
            throw new NotImplementedException();
        }

        public void onMessageResponse(string command, dynamic data)
        {
            if(command == "user/add")
            {
                BeginInvoke((Action) (() => this.Close()));
            }
        }

        public void onMessageResponseError(string command, string info)
        {
            throw new NotImplementedException();
        }
    }
}
