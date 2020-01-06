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
using Patient.Communication;

namespace Patient
{
    public partial class Form1 : Form, ConnectionEventListener, ConnectionResponseListener
    {
        private Connection c;
        private Guid id;
        public Form1()
        {
            InitializeComponent();
            StartConnection();
            this.id = Guid.Empty;
        }

        private void StartConnection()
        {
            c = new Connection("localhost", 25565, this);
            c.setParentForm(this, this);
        }

        public void onConnectionError(Connection c, Exception e)
        {
            Console.WriteLine("[Patient]: " + e.Message);
        }

        public void onDataReceived(Connection c, byte[] data, ushort length)
        {
            if (this.Visible)
            {
                String message = Encoding.UTF8.GetString(data);
                DataRouter.GetInstance().OnMessageReceived(c, message);
            }
            
        }

        public void onMessageResponse(string command, dynamic data)
        {
            if (command == "user/login")
                this.id = new Guid((string)data.info);
        }

        public void onMessageResponseError(string command, string info)
        {
            throw new NotImplementedException();
        }

        private void DummyButton_Click(object sender, EventArgs e)
        {
            
            DataRouter.GetInstance().SendMessage(c, Datapackages.Message_GetFilenames(id, "resources//data", "txt"), "file/getnames", this, true);
        }

        public void onGenericMessageReceived(string command, dynamic data)
        {
            Debug.WriteLine((String)data.data.msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRouter.GetInstance().SendMessage(c, Datapackages.Message_Login("Rick", "123", Datapackages.USERTYPES.DOCTOR), "user/login", this, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRouter.GetInstance().SendMessage(c, Datapackages.Message_Message(id.ToString(), id.ToString(), "Helloworld"), "user/msg", this, false);
        }
    }
}
