using System;

using TelemetryId = System.UInt16;

namespace Telemetry.Protocol.Datapool
{
    public class ValueAccessor
    {
        /* datapool access interface objects */
        private readonly IValueReader valueReader;
        private readonly IValueWriter valueWriter;

        /* constructor */
        public ValueAccessor(IValueReader valueReader, IValueWriter valueWriter)
        {
            this.valueReader = valueReader;
            this.valueWriter = valueWriter;
        }

        #region internal helper
        protected float ReadFloat(TelemetryId id)
        {
            return valueReader.ReadFloat(id);
        }

        protected void WriteFloat(TelemetryId id, float value)
        {
            valueWriter.WriteFloat(id, value);
        }

        protected int ReadInt(TelemetryId id)
        {
            return valueReader.ReadInt(id);
        }

        protected void WriteInteger(TelemetryId id, int value)
        {
            valueWriter.WriteInteger(id, value);
        }
        #endregion
    }
}
