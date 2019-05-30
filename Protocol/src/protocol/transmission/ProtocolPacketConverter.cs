using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Telemetry.Protocol.Transmission
{
    public class ProtocolPacketConverter
    {
        /* local buffer */
        private byte[] buffer;

        /* pre-encoded value type IDs */
        private readonly Dictionary<TelemetryValueTypeID, byte[]> valueTypeData;

        /* properties */
        private readonly bool skipUnchangedValues = false;

        /* constructor */
        public ProtocolPacketConverter(int startBufferSize = 2048, bool skipUnchangedValues = false)
        {
            this.buffer = new byte[startBufferSize];
            this.valueTypeData = new Dictionary<TelemetryValueTypeID, byte[]>();
            this.skipUnchangedValues = skipUnchangedValues;

            PreEncodeValueTypeIDs();
        }

        private void PreEncodeValueTypeIDs()
        {
            var typeIDs = (TelemetryValueTypeID[])Enum.GetValues(typeof(TelemetryValueTypeID));

            foreach (TelemetryValueTypeID typeID in typeIDs)
            {
                var data = BitConverter.GetBytes((sbyte)typeID);
                valueTypeData.Add(typeID, data);
            }
        }

        /* api */
        public byte[] GetBytesFromValues(ITelemetryValue[] values)
        {
            int currentOffset = 0;

            foreach (ITelemetryValue value in values)
            {
                if (!skipUnchangedValues || value.Changed)
                {
                    CopyValue(value, ref currentOffset);
                }
#if DEBUG
                else
                {
                    Debug.WriteLine($"Skipping unchanged value. ID: {value.ID}");
                }
#endif
            }

            var data = new byte[currentOffset];
            Buffer.BlockCopy(buffer, 0, data, 0, currentOffset);

            return data;
        }

        #region generic extraction
        private void CopyValue<T>(T value, ref int currentOffset) where T : ITelemetryValue
        {
            var data = GetBytes(value);
            var size = data.Length;

            if (currentOffset + size >= buffer.Length)
            {
                Array.Resize(ref buffer, buffer.Length * 2);
            }

            if (size > 0)
            {
                Buffer.BlockCopy(data, 0, buffer, currentOffset, size);
                currentOffset += size;
            }
        }

        private byte[] GetBytes<T>(T value) where T : ITelemetryValue
        {
            switch (value)
            {
                case TelemetryValue<float> f:
                    return GetBytesFromFloat(f);
                case TelemetryValue<int> i:
                    return GetBytesFromInteger(i);
                case TelemetryValue<bool> b:
                    return GetBytesFromBool(b);
                case TelemetryValue<string> s:
                    return GetEncodedStringBytes(s);
                default:
                    throw new NotImplementedException("Value type not supported");
            }
        }
        #endregion

        #region specific conversion
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private byte[] CreateNewValueBuffer(int size)
        {
            // typeID + value ID + value size
            return new byte[sizeof(sbyte) + sizeof(UInt16) + size];
        }

        private byte[] GetBytesFromFloat(TelemetryValue<float> f)
        {
            byte[] data = CreateNewValueBuffer(sizeof(float));

            Buffer.BlockCopy(valueTypeData[TelemetryValueTypeID.Float], 0, data, 0, sizeof(sbyte)); // type ID
            Buffer.BlockCopy(BitConverter.GetBytes(f.ID), 0, data, sizeof(sbyte), sizeof(UInt16)); // value ID
            Buffer.BlockCopy(BitConverter.GetBytes(f.Current), 0, data, sizeof(sbyte) + sizeof(UInt16), sizeof(float)); // value 

            return data;
        }

        private byte[] GetBytesFromInteger(TelemetryValue<int> i)
        {
            byte[] data = CreateNewValueBuffer(sizeof(int));

            Buffer.BlockCopy(valueTypeData[TelemetryValueTypeID.Integer], 0, data, 0, sizeof(sbyte)); // type ID
            Buffer.BlockCopy(BitConverter.GetBytes(i.ID), 0, data, sizeof(sbyte), sizeof(UInt16)); // value ID
            Buffer.BlockCopy(BitConverter.GetBytes(i.Current), 0, data, sizeof(sbyte) + sizeof(UInt16), sizeof(int)); // value 

            return data;
        }

        private byte[] GetBytesFromBool(TelemetryValue<bool> b)
        {
            byte[] data = CreateNewValueBuffer(sizeof(sbyte));

            Buffer.BlockCopy(valueTypeData[TelemetryValueTypeID.Bool], 0, data, 0, sizeof(sbyte)); // type ID
            Buffer.BlockCopy(BitConverter.GetBytes(b.ID), 0, data, sizeof(sbyte), sizeof(UInt16)); // value ID
            Buffer.BlockCopy(BitConverter.GetBytes(b.Current ? (sbyte)1 : (sbyte)0), 0, data, sizeof(sbyte) + sizeof(UInt16), sizeof(int)); // value 

            return data;
        }

        private byte[] GetEncodedStringBytes(TelemetryValue<string> s)
        {
            byte[] encodedStringData = Encoding.UTF8.GetBytes(s.Current);
            byte[] data = CreateNewValueBuffer(sizeof(UInt16) + encodedStringData.Length);

            Buffer.BlockCopy(valueTypeData[TelemetryValueTypeID.String], 0, data, 0, sizeof(sbyte)); // type ID
            Buffer.BlockCopy(BitConverter.GetBytes(s.ID), 0, data, sizeof(sbyte), sizeof(UInt16)); // value ID
            Buffer.BlockCopy(BitConverter.GetBytes((UInt16)s.Current.Length), 0, data, sizeof(sbyte) + sizeof(UInt16), sizeof(UInt16)); // string size
            Buffer.BlockCopy(encodedStringData, 0, data, sizeof(sbyte) + sizeof(UInt16) + sizeof(UInt16), encodedStringData.Length);

            return data;
        }
        #endregion
    }
}
