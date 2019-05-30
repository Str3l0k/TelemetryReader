using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemetry.Protocol.Datapool;

namespace Telemetry.Processing.Calculation
{
    public interface ITelemetryCalculation
    {
        void Calculate(TelemetryDatapool datapool);
    }
}
