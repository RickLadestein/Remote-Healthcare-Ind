using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Bike
{
    interface IBikeMeasurementListener
    {
        void OnMeasurementReceived(BikeMeasurement measurement);
    }
}
