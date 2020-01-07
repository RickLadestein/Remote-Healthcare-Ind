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
    public partial class Form1 : Form, ConnectionResponseListener
    {
        private Socket c;
        private Guid id;
        public Form1()
        {
            InitializeComponent();
            StartConnection();
            this.id = Guid.Empty;
        }

        private void StartConnection()
        {
            c = new Socket("localhost", 25565);
            c.onMessageReceived += OnMessageReceived;
            c.onSocketError += OnSocketError;
            c.Start();
            DataRouter.GetInstance().setGenericMessageListener(this);
        }


        public void OnMessageReceived(Socket handle, byte[] data, int length)
        {
            if (this.Visible)
            {
                String message = Encoding.UTF8.GetString(data);
                DataRouter.GetInstance().OnMessageReceived(handle, message);
            }
        }
        public void OnSocketError(Socket s, String message)
        {
            Console.WriteLine("[Patient]: " + message);
        }

        public void onMessageResponse(string command, dynamic data)
        {
            if (command == "user/login")
                this.id = new Guid((string)data.info);
        }

        public void onMessageResponseError(string command, string info)
        {
            Debug.WriteLine("Errors are not implemented yet");
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
            DataRouter.GetInstance().SendMessage(c, Datapackages.Message_Login("Rick", "321", Datapackages.USERTYPES.DOCTOR), "user/login", this, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRouter.GetInstance().SendMessage(c, Datapackages.Message_Message(id.ToString(), id.ToString(), "Helloworld"), "user/msg", this, false);
        }
    }
}
