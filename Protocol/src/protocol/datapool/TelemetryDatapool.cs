using System;
using System.Collections.Generic;
using System.Linq;

// value Aliases
using TelemetryId = System.UInt16;

namespace Telemetry.Protocol.Datapool
{
    public class TelemetryDatapool : IValueWriter, IValueReader
    {
        /* value dict */
        private readonly Dictionary<TelemetryId, ITelemetryValue> Values;
        public ITelemetryValue[] ValueArray => Values.Values.ToArray();

        /* properties */
        private readonly bool addValuesOnWrite = true;

        /* value category access apis */
        public Car car;
        public IDriver driver;
        public ISession session;

        /* constructor */
        public TelemetryDatapool()
        {
            this.Values = new Dictionary<TelemetryId, ITelemetryValue>();
            this.car = new Car(this, this);
        }

        public TelemetryDatapool(bool addValuesOnWrite) : this()
        {
            this.addValuesOnWrite = addValuesOnWrite;
        }

        /* value control */
        #region add values
        private void AddValue<T>(TelemetryId id)
        {
            Values.Add(id, new TelemetryValue<T>(id));
        }

        public void AddBoolValue(TelemetryId id)
        {
            AddValue<bool>(id);
        }

        public void AddFloatValue(TelemetryId id)
        {
            AddValue<float>(id);
        }

        public void AddIntegerValue(TelemetryId id)
        {
            AddValue<int>(id);
        }

        public void AddStringValue(TelemetryId id)
        {
            AddValue<string>(id);
        }
        #endregion

        public void InitValues(params KeyValuePair<TelemetryId, TypeCode>[] values)
        {
            foreach (KeyValuePair<TelemetryId, TypeCode> valueData in values)
            {
                switch (valueData.Value)
                {
                    case TypeCode.Boolean:
                        AddBoolValue(valueData.Key);
                        break;
                    case TypeCode.Single:
                        AddFloatValue(valueData.Key);
                        break;
                    case TypeCode.Int32:
                        AddIntegerValue(valueData.Key);
                        break;
                    case TypeCode.String:
                        AddStringValue(valueData.Key);
                        break;
                }
            }
        }

        public void InitValues(params ITelemetryValue[] values)
        {
            foreach (ITelemetryValue value in values)
            {
                Values.Add(value.ID, value);
            }
        }

        /* value access */
        #region write 
        internal void WriteValue<T>(TelemetryId id, T value)
        {
            if (addValuesOnWrite && !Values.ContainsKey(id))
            {
                Values.Add(id, new TelemetryValue<T>(id));
            }

            if (Values.ContainsKey(id) && Values[id] is TelemetryValue<T> telemetryValue)
            {
                telemetryValue.Value = value;
            }
#if DEBUG
            else
            {
                Console.WriteLine($"Given value with id {id} has different type or does not exist.");
            }
#endif
        }

        public void WriteFloat(TelemetryId id, float value)
        {
            WriteValue(id, value);
        }

        public void WriteInteger(TelemetryId id, int value)
        {
            WriteValue(id, value);
        }

        public void WriteStringValue(TelemetryId id, string value)
        {
            WriteValue(id, value);
        }

        public void WriteBoolValue(TelemetryId id, bool value)
        {
            WriteValue(id, value);
        }
        #endregion

        #region read
        internal T ReadValue<T>(TelemetryId id)
        {
            if (Values.ContainsKey(id) && Values[id] is TelemetryValue<T> telemetryValue)
            {
                return telemetryValue.Value;
            }

            return default;
        }

        public int ReadInt(TelemetryId id)
        {
            return ReadValue<int>(id);
        }

        public float ReadFloat(TelemetryId id)
        {
            return ReadValue<float>(id);
        }

        public bool ReadBool(TelemetryId id)
        {
            return ReadValue<bool>(id);
        }

        public string ReadString(TelemetryId id)
        {
            return ReadValue<string>(id);
        }
        #endregion
    }
}
