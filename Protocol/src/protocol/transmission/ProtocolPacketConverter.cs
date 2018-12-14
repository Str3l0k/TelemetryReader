using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Telemetry.Protocol.Transmission
{
    class ProtocolPacketConverter
    {
        /* local buffer */
        private byte[] buffer;

        /* constructor */
        public ProtocolPacketConverter(int startBufferSize = 2048)
        {
            this.buffer = new byte[startBufferSize];
        }

        /* api */
        public byte[] GetBytesFromValues(ITelemetryValue[] values)
        {
            int currentOffset = 0;

            foreach (ITelemetryValue value in values)
            {
                switch (value)
                {
                    case TelemetryValue<float> tFloat:
                        break;
                    case TelemetryValue<int> tInt:
                        break;
                    case TelemetryValue<bool> tBool:
                        break;
                    case TelemetryValue<string> tString:
                        break;
                    default:
                        break;
                }
            }

            return new byte[] { 0 };
        }

        private void CopyValue<T>(T value, int currentOffset)
        {
            var valueSize = Marshal.SizeOf(value);
            Buffer.BlockCopy(GetBytes(value), 0, buffer, currentOffset, valueSize);
        }

        private byte[] GetBytes<T>(T value)
        {
            switch (value)
            {
                case float f:
                    return BitConverter.GetBytes(f);
                case int i:
                    return BitConverter.GetBytes(i);
                case bool b:
                    return BitConverter.GetBytes(b ? (sbyte) 1 : (sbyte) 0);
                case string s:
                    return GetEncodedStringBytes(s);
                default:
                    return new byte[0];
            }
        }

        private byte[] GetEncodedStringBytes(string s)
        {
            byte[] length = GetBytes((UInt16) s.Length);
            byte[] encodedString = Encoding.UTF8.GetBytes(s);

            byte[] result = new byte[length.Length + encodedString.Length];
            Buffer.BlockCopy(length, 0, result, 0, length.Length);
            Buffer.BlockCopy(length, 0, result, length.Length, encodedString.Length);

            return result;
        }
    }
}
