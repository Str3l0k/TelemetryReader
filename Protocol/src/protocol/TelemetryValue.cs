using System;

namespace Telemetry.Protocol
{
    public enum TelemetryValueType: sbyte
    {
        Float,
        Integer,
        String,
        Bool,
        Unknown
    }

    public interface ITelemetryValue
    {
        UInt16 ID { get; }
        TelemetryValueType Type { get; }
    }

    public class TelemetryValue<T> : ITelemetryValue
    {
        /* properties */
        public UInt16 ID { get; private set; }
        public TelemetryValueType Type { get; private set; }
        public T Value { get; set; }

        /* constructor */
        public TelemetryValue(UInt16 id)
        {
            this.ID = id;
            this.Type = CheckValueType();
        }

        private TelemetryValueType CheckValueType()
        {
            switch (Value)
            {
                case float f:
                    return TelemetryValueType.Float;
                case int i:
                    return TelemetryValueType.Integer;
                case string s:
                    return TelemetryValueType.String;
                case bool b:
                    return TelemetryValueType.Bool;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
