using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Commands.Receive
{
    class BikeMeasurement
    {
        public byte[] data;

        public uint page;
        public uint eq_type;
        public double delta_time;
        public uint distance;
        public double speed;
        public uint heartrate;
        public uint bikestate;

        public BikeMeasurement(uint page, uint eq_type, double delta_time, uint distance, double speed, uint heartrate, uint bikestate)
        {
            this.page = page;
            this.eq_type = eq_type;
            this.delta_time = delta_time;
            this.distance = distance;
            this.speed = speed;
            this.heartrate = heartrate;
            this.bikestate = bikestate;
        }

        public static BikeMeasurement ParseData(byte[] package)
        {
            if(package[1] != (package.Length - 4))
            {
                throw new Exception("data size does not match the package size in header");
            }

            try
            {

                //Header
                uint sync = (uint)package[0];
                uint length = (uint)package[1];
                uint keyword = (uint)package[2];
                uint irrelevant = (uint)package[3];

                if (package[4] != 0x10)
                {
                    throw new Exception("Page number does not match");
                }

                uint page = (uint)package[4];
                uint eq_type = (uint)package[5];
                double delta_time = Convert.ToDouble(0b0000 | package[6]) * 0.25;
                uint distance = (uint)package[7];
                double speed = ((package[9] << 8) | package[8]) / 1000;
                uint heartrate = (uint)((package[10] == 0xFF) ? 0 : package[10]);
                uint bikestate = (uint)(package[11] >> 4);

                return new BikeMeasurement(page, eq_type, delta_time, distance, speed, heartrate, bikestate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public override string ToString()
        {
            return "BikeMeasurement {\n" +
                "page: " + page + "\n" +
                "eq_type: " + eq_type + " \n" +
                "time: " + delta_time + " s \n" +
                "distance: " + distance + " m \n" +
                "speed: " + speed + " m/s \n" +
                "heartrate: " + heartrate + " bps \n" +
                "bike_state: " + bikestate + "\n}";
        }
    }
}
