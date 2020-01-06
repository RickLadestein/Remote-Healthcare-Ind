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
    public partial class DocLoginForm : Form
    {
        Doctor doc;

        public DocLoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (VerifyLogin(txtUsername.Text, txtPassword.Text))
            {
                //MessageBox.Show("Hoi " + txtUsername.Text + "!");
                //Form main = new AstrandDoctorGUI(this, new Doctor(txtUsername.Text, txtPassword.Text));
                //main.Parent = this;
                //main.Show();
                //this.Hide();
                doc = new Doctor(txtUsername.Text, txtPassword.Text);
                this.Close();
            }
            else
            {
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
                MessageBox.Show("This username and password combination is incorrect.");
            }
        }

        private bool VerifyLogin(string username, string password)
        {
            // TODO: Actual security check
            return true;
        }

        private void CloseApp()
        {
            this.Close();
        }

        private void DocLoginForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public Doctor GetDoctor()
        {
            return doc;
        }
    }
}
