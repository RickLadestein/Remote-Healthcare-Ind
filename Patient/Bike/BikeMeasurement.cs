using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Bike
{
    public class BikeMeasurement
    {
        public int Bpm { get; }
        public int Rpm { get; }
        public double Speed { get; }
        public double Distance { get; }
        public int Resistance { get; }
        public int Energy { get; }
        public TimeSpan Time { get; }

        public BikeMeasurement(int bpm, int rpm, double speed, double distance, int resistance, int energy, TimeSpan time)
        {
            Bpm = bpm;
            Rpm = rpm;
            Speed = speed * 0.1;
            Distance = distance * 0.1;
            Resistance = resistance;
            Energy = energy;
            Time = time;
        }

        public override string ToString()
        {
            return $"BPM:{this.Bpm} \n RPM:{this.Rpm} \n SPEED:{this.Speed} \n DISTANCE:{this.Distance} \n RESISTANCE:{this.Resistance} \n ENERGY:{this.Energy} \n TIME:{this.Time.ToString()}";
        }
    }
}
