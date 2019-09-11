using System;
using System.Collections.Generic;
using System.Text;

namespace RHServer.Networking
{
    enum ConnectionType
    {
        DOCTOR = 0x00,
        PATIENT = 0x01,
        VIEWER = 0x02
    }
}
