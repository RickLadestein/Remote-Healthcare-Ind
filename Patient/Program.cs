using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patient.Commands;
using Patient.Commands.Receive;
using Patient.Communication.Bluetooth;

namespace Patient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            BluetoothConnection c = BluetoothConnection.GetInstance();
            c.Connect("Tacx Flux 00457", "6e40fec1-b5a3-f393-e0a9-e50e24dcca9e");

            //BikeMeasurement measurement = BikeMeasurement.ParseData(new byte[] { 0xA4, 0x09, 0x4E, 0x05, 0x10, 0x19, 0x03, 0xED, 0x00, 0x00, 0xFF, 0x24, 0xDA });
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
