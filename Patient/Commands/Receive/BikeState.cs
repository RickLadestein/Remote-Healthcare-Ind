using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Commands.Receive
{
    enum BikeState
    {
        RESERVED = 0x0,
        ASLEEP = 0x01,
        READY = 0x02,
        IN_USE = 0x03
    }
}
