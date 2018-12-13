using System;

namespace Telemetry.Protocol
{
    public interface ITelemetryValue
    {
        UInt16 ID { get; }
    }

    public class TelemetryValue<T> : ITelemetryValue
    {
        /* properties */
        public UInt16 ID { get; private set; }
        public T Value { get; set; } = default;

        /* constructor */
        public TelemetryValue(UInt16 id)
        {
            this.ID = id;
        }
    }
}
