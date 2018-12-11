using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelemetryReader.src.protocol
{
    public class ProtocolPacketHeader
    {
        /*  identifier array - TELEMETRYBARZ */
        public static readonly byte[] HEADER_IDENTIFIER = { 0x54, 0x45, 0x4C, 0x45, 0x4D, 0x45, 0x54, 0x52, 0x59, 0x42, 0x41, 0x52, 0x5A };
        public static readonly byte[] DATA_START = { 0x44, 0x41, 0x54, 0x44 };

        /* modifier bits */
        public static int REALTIMEBIT = 1 << 0;

        /* actual length in bytes */
        public static readonly int TOTAL_HEADER_SIZE = HEADER_IDENTIFIER.Length +
                                                       8 + 2 + 4 + 1 + // size of actual header data
                                                       DATA_START.Length;

        /* buffers */
        public byte[] headerBuffer { get; }

        /* header data */
        private Int64 packetNumber;
        private Int16 valueCount;
        private int protocolID;
        private byte modifierBitfield;

        public Int64 PacketNumber
        {
            get
            {
                return packetNumber;
            }

            set
            {
                packetNumber = value;
                setPacketNumber(value);
            }
        }

        public Int16 ValueCount
        {
            get
            {
                return valueCount;
            }

            set
            {
                valueCount = value;
                setProtocolVersion(valueCount);
            }
        }

        public int ProtocolID
        {
            get
            {
                return protocolID;
            }
            set
            {
                protocolID = value;
                setProtocolID(protocolID);
            }
        }

        public byte ModifierBitfield
        {
            get
            {
                return modifierBitfield;
            }

            set
            {
                modifierBitfield = value;
                setModifierBitfield(modifierBitfield);
            }
        }

        /* constructor */
        public ProtocolPacketHeader(Int16 protocolVersion)
        {
            this.headerBuffer = new byte[TOTAL_HEADER_SIZE];
            this.valueCount = protocolVersion;

            fillBuffer();
        }

        private void fillBuffer()
        {
            Buffer.BlockCopy(HEADER_IDENTIFIER, 0, headerBuffer, 0, HEADER_IDENTIFIER.Length);
            PacketNumber = 0;
            setProtocolVersion(valueCount);
            setProtocolID(0xF0F0F0); // test ID
            setModifierBitfield(0);
            Buffer.BlockCopy(DATA_START, 0, headerBuffer, TOTAL_HEADER_SIZE - DATA_START.Length, DATA_START.Length);
        }

        private void setPacketNumber(Int64 number)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(number), 0, headerBuffer, HEADER_IDENTIFIER.Length, 8);
        }

        private void setProtocolVersion(Int16 version)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(valueCount), 0, headerBuffer, HEADER_IDENTIFIER.Length + 8, 2);
        }

        private void setProtocolID(int id)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(protocolID), 0, headerBuffer, HEADER_IDENTIFIER.Length + 8 + 2, 4);
        }

        private void setModifierBitfield(byte bitfield)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(bitfield), 0, headerBuffer, HEADER_IDENTIFIER.Length + 8 + 2 + 4, 1);
        }
    }
}
