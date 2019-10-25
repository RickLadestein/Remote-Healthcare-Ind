using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avans.TI.BLE;
using Patient.Commands.Receive;

namespace Patient.Communication.Bluetooth
{
    class BluetoothConnection
    {
        private BLE bike;

        public static BluetoothConnection instance;
        public static BluetoothConnection GetInstance()
        {
            if (instance == null)
                instance = new BluetoothConnection();
            return instance;
        }

        private BluetoothConnection()
        {
            this.bike = new BLE();
            System.Threading.Thread.Sleep(1000);
        }

        public async Task Connect(string id, params String[] services)
        {
            //Assumption RESULT: >0 == ERROR
            int result = await bike.OpenDevice(id);
            if (result > 0)
            {
                Console.WriteLine($"Could not connect to bike {id}");
                return;
            }


            bike.SubscriptionValueChanged += OnDataReceived;

            foreach (String s in services)
            {
                int result2 = await bike.SetService(s);
                int result3 = await bike.SubscribeToCharacteristic("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e");
                if (result2 > 0 || result3 > 0)
                    Console.WriteLine($"Could not subscribe to service {s}");
            }

            Console.WriteLine("Bike connection all set up!");
            return;
        }

        private static void OnDataReceived(object sender, BLESubscriptionValueChangedEventArgs e)
        {
            if(e.Data[4] == 0x10)
            {
                Console.WriteLine(BikeMeasurement.ParseData(e.Data).ToString());
                Console.WriteLine("");
            }
        }
    }
}
