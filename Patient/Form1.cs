using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Form1()
        {
            InitializeComponent();
            StartConnection();
        }

        private void StartConnection()
        {
            c = new Connection("localhost", 25565, this);
        }

        public void onConnectionError(Connection c, Exception e)
        {
            Console.WriteLine("[Patient]: " + e.Message);
        }

        public void onDataReceived(Connection c, byte[] data, ushort length)
        {
            String message = Encoding.UTF8.GetString(data);
            DataRouter.GetInstance().OnMessageReceived(c, message);
        }

        public void onMessageResponse(string command, object data)
        {
            Console.WriteLine(data);
        }

        public void onMessageResponseError(string command, string info)
        {
            throw new NotImplementedException();
        }

        private void DummyButton_Click(object sender, EventArgs e)
        {
            DataRouter.GetInstance().SendMessage(c, Datapackages.Message_GetFilenames("resources//data", "txt"), "file/getnames", this, true);
        }
    }
}
