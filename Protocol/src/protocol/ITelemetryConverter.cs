using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemetry.Protocol.Datapool;

namespace Telemetry.Protocol
{
    public interface ITelemetryConverter
    {
        void InitValues();

        void WriteValuesIntoDatapool(TelemetryDatapool datapool);
    }
}
