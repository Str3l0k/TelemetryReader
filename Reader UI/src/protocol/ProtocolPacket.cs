using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelemetryReader.src.protocol;

namespace TelemetryReader.src.protocol
{
    class ProtocolPacketData
    {
        public readonly int BUFFER_SIZE = 3072;

        /* actual byte buffer */
        private byte[] packetBuffer;
        private SendData sendData;
        
        /* constructor */
        public ProtocolPacketData()
        {
            packetBuffer = new byte[BUFFER_SIZE];
            sendData = new SendData();
            sendData.data = packetBuffer;
        }

        public SendData getData(IEnumerable<ProtocolValue> values)
        {
            int offset = 0;

            foreach (ProtocolValue value in values)
            {
                sbyte type = value.type;
                UInt16 ID = value.ID;

                Buffer.BlockCopy(BitConverter.GetBytes(type), 0, packetBuffer, offset, 1);
                offset += 1;

                Buffer.BlockCopy(BitConverter.GetBytes(ID), 0, packetBuffer, offset, 2);
                offset += 2;

                switch (type)
                {
                    case 0x1: // float
                        float v = ((ProtocolValue<float>)value).value;
                        Buffer.BlockCopy(BitConverter.GetBytes(v), 0, packetBuffer, offset, 4);
                        offset += 4;
                        break;
                    case 0x2: // integer
                        int i = ((ProtocolValue<int>)value).value;
                        Buffer.BlockCopy(BitConverter.GetBytes(i), 0, packetBuffer, offset, 4);
                        offset += 4;
                        break;
                    case 0x3: // string
                        string s = ((ProtocolValue<string>)value).value;
                        offset = computeString(s, offset);
                        break;
                    case 0x4: // bitfield
                        int b = ((ProtocolValue<int>)value).value;
                        Buffer.BlockCopy(BitConverter.GetBytes(b), 0, packetBuffer, offset, 4);
                        offset += 4;
                        break;
                    default:
                        break;
                }

                if (offset >= packetBuffer.Length)
                {
                    break;
                }
            }

            sendData.data = packetBuffer;
            sendData.size = offset;
            sendData.count = (short) values.Count();

            return sendData;
        }

        private int computeString(string s, int offset)
        {            
            byte[] encodedString = Encoding.UTF8.GetBytes(s);
            Buffer.BlockCopy(BitConverter.GetBytes(encodedString.Length), 0, packetBuffer, offset, 4);
            offset += 4;
            Buffer.BlockCopy(encodedString, 0, packetBuffer, offset, encodedString.Length);
            offset += encodedString.Length;

            return offset;
        }
    }
}
