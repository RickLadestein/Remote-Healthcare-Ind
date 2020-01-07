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
    public partial class DocLoginForm : Form, ConnectionResponseListener
    {
        Doctor doc;
        Socket socket;

        public DocLoginForm(Socket s)
        {
            InitializeComponent();
            this.socket = s;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            DataRouter.GetInstance().SendMessage(socket, Datapackages.Message_Login(txtUsername.Text, txtPassword.Text, Datapackages.USERTYPES.DOCTOR), "user/login", this, true);
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

        public void onMessageResponse(string command, dynamic data)
        {
            if(command == "user/login")
            {
                Guid id = new Guid((string)data.info);
                String username = (string)data.data.username;
                doc = new Doctor(username, id);
                BeginInvoke((Action)(() => this.Close()));
            }
        }

        public void onMessageResponseError(string command, string info)
        {
            BeginInvoke((Action)(() => txtUsername.Clear()));
            BeginInvoke((Action)(() => txtPassword.Clear()));
            BeginInvoke((Action)(() => txtUsername.Focus()));
            BeginInvoke((Action)(() => MessageBox.Show(info)));
        }

        public void onGenericMessageReceived(string command, dynamic data)
        {
            throw new NotImplementedException();
        }
    }
}
