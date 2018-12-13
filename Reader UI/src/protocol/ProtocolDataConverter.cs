using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace TelemetryReader.src.protocol
{
    public interface IProtocolDataConverter
    {
        Dictionary<UInt16, ProtocolValue> convertValues(SendData gameData);
    }

    public interface IDataWriter
    {
        void writeFloatValue(UInt16 ID, float value);
        void writeIntegerValue(UInt16 ID, int value);
        void writeStringValue(UInt16 ID, string value);
        void writeBitfieldValue(UInt16 ID, int bitfield);
    }

    // This is the class to be created per game
    public abstract class ProtocolDataConverter<T> : IProtocolDataConverter, IDataWriter
    {
        /* category abstraction */
        //protected Car car;
        protected Driver driver;
        protected Session session;

        /* actual game based data structure or class */
        protected T data;

        /* list for sending values */
        protected Dictionary<ushort, ProtocolValue> valueDictionary;

        /* constructor */
        public ProtocolDataConverter()
        {
            //valueList = new List<ProtocolValue>();
            valueDictionary = new Dictionary<ushort, ProtocolValue>();
            data = initDataStruct();

            //this.car = new Car(this);
            this.driver = new Driver(this);
            this.session = new Session(this);
        }

        public Dictionary<ushort, ProtocolValue> convertValues(SendData gameData)
        {
            marshalDataToStruct(gameData);
            //writeCarValues(car, data);
            return valueDictionary;
        }

        protected void marshalDataToStruct(SendData gameData)
        {
            var size = Marshal.SizeOf(typeof(T));

            //if (gameData.size != size)
            //{
            //    return;
            //}

            var ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(gameData.data, 0, ptr, size);
            data = (T) Marshal.PtrToStructure(ptr, data.GetType());
            Marshal.FreeHGlobal(ptr);
        }

        protected abstract T initDataStruct();

        //protected abstract void writeCarValues(Car car, T data);

        protected abstract void writeDriverValues(Driver driver, T data);

        protected abstract void writeSessionValues(Session session, T data);

        protected void writeValues(T data)
        {
            //writeCarValues(car, data);
            writeDriverValues(driver, data);
            writeSessionValues(session, data);
        }

        /* actual value methods */
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void writeFloatValue(ushort ID, float value)
        {
            if (!valueDictionary.ContainsKey(ID))
            {
                ProtocolValue<float> pV = new ProtocolValue<float>(ID);
                valueDictionary.Add(ID, pV);
            }

            var pValue = valueDictionary[ID];

            if (pValue.type == ProtocolValue.FLOAT)
            {
                ((ProtocolValue<float>)pValue).value = value;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void writeIntegerValue(UInt16 ID, int value)
        {
            if (!valueDictionary.ContainsKey(ID))
            {
                ProtocolValue<int> pV = new ProtocolValue<int>(ID);
                valueDictionary.Add(ID, pV);
            }

            ProtocolValue pValue = valueDictionary[ID];

            if (pValue.type == 0x2)
            {
                ((ProtocolValue<int>)pValue).value = value;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void writeStringValue(UInt16 ID, string value)
        {
            if (!valueDictionary.ContainsKey(ID))
            {
                ProtocolValue<string> pV = new ProtocolValue<string>(ID);
                valueDictionary.Add(ID, pV);
            }

            ProtocolValue pValue = valueDictionary[ID];

            if (pValue.type == 0x3)
            {
                ((ProtocolValue<string>)pValue).value = value;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void writeBitfieldValue(UInt16 ID, int value)
        {
            if (!valueDictionary.ContainsKey(ID))
            {
                ProtocolValue<int> pV = new ProtocolValue<int>(0x4, ID);
                valueDictionary.Add(ID, pV);
            }

            ProtocolValue pValue = valueDictionary[ID];

            if (pValue.type == 0x4)
            {
                ((ProtocolValue<int>)pValue).value = value;
            }
        }
    }
}
