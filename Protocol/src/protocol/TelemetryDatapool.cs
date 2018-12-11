using System;
using System.Collections.Generic;

namespace Telemetry.Protocol
{
    class TelemetryDatapool
    {
        /* value dict */
        private readonly Dictionary<UInt16, ITelemetryValue> Values;

        /* properties */
        private readonly bool addValuesOnWrite = true;

        /* constructor */
        public TelemetryDatapool()
        {
            this.Values = new Dictionary<ushort, ITelemetryValue>();
        }

        public TelemetryDatapool(bool addValuesOnWrite) : this()
        {
            this.addValuesOnWrite = addValuesOnWrite;
        }

        /* value control */
        #region add values
        private void AddValue<T>(UInt16 id)
        {
            Values.Add(id, new TelemetryValue<T>(id));
        }

        public void AddBoolValue(UInt16 id)
        {
            AddValue<bool>(id);
        }

        public void AddFloatValue(UInt16 id)
        {
            AddValue<float>(id);
        }

        public void AddIntegerValue(UInt16 id)
        {
            AddValue<int>(id);
        }

        public void AddStringValue(UInt16 id)
        {
            AddValue<string>(id);
        }
        #endregion

        public void InitValues(params KeyValuePair<UInt16, TelemetryValueType>[] values)
        {
            foreach (KeyValuePair<UInt16, TelemetryValueType> valueData in values)
            {
                switch (valueData.Value)
                {
                    case TelemetryValueType.Bool:
                        AddBoolValue(valueData.Key);
                        break;
                    case TelemetryValueType.Float:
                        AddFloatValue(valueData.Key);
                        break;
                    case TelemetryValueType.Integer:
                        AddIntegerValue(valueData.Key);
                        break;
                }
            }
        }

        /* value access */
        #region write 
        internal void WriteValue<T> (UInt16 id, T value, TelemetryValueType type)
        {
            if (addValuesOnWrite && !Values.ContainsKey(id))
            {
                Values.Add(id, new TelemetryValue<T>(id));
            }

            if (Values[id]?.Type != type)
            {
                return;
            }

            (Values[id] as TelemetryValue<T>).Value = value;
        }

        public void WriteFloatValue(UInt16 id, float value)
        {
            WriteValue(id, value, TelemetryValueType.Float);
        }

        public void WriteIntegerValue(UInt16 id, int value)
        {
            WriteValue(id, value, TelemetryValueType.Integer);
        }

        public void WriteStringValue(UInt16 id, string value)
        {
            WriteValue(id, value, TelemetryValueType.String);
        }

        public void WriteBoolValue(UInt16 id, bool value)
        {
            WriteValue(id, value, TelemetryValueType.Bool);
        }
        #endregion

        #region read
        #endregion
    }
}
