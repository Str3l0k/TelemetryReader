using System;
using System.Runtime.InteropServices;
using Telemetry.Utilities;

namespace Telemetry.Protocol.Transmission
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ProtocolHeaderData
    {
        //internal byte[] ID;
        internal sbyte ProtocolVersion;
        internal Int64 PacketNumber;
        internal Int16 ValueCount;
    }
    
    public class ProtocolPacketHeader
    {
        /*  identifier array - TLMTRY */
        public static readonly byte[] HEADERID = { 0x54, 0x4C, 0x4D, 0x54, 0x52, 0x59 };

        /* buffer data */
        private byte[] HeaderBuffer;
        public byte[] HeaderData => HeaderBuffer;

        /* header values */
        private ProtocolHeaderData ProtocolHeaderData;

        /* constructor */
        public ProtocolPacketHeader(sbyte protocolVersion)
        {
            this.ProtocolHeaderData = new ProtocolHeaderData
            {
                PacketNumber = 0,
                ProtocolVersion = protocolVersion
            };

            var headerSize = Marshal.SizeOf(typeof(ProtocolHeaderData));

            this.HeaderBuffer = new byte[HEADERID.Length + headerSize];
            Buffer.BlockCopy(HEADERID, 0, HeaderBuffer, 0, HEADERID.Length);

            UpdateBuffer();
        }

        private void UpdateBuffer()
        {
            StructMarshal.MarshalStructToRawData(ProtocolHeaderData, ref HeaderBuffer, HEADERID.Length);
        }

        /* properties */
        public Int64 PacketNumber
        {
            get => ProtocolHeaderData.PacketNumber;
            set
            {
                ProtocolHeaderData.PacketNumber = value;
                UpdateBuffer();
            }
        }

        public Int16 ValueCount
        {
            get => ProtocolHeaderData.ValueCount;
            set
            {
                ProtocolHeaderData.ValueCount = value;
                UpdateBuffer();
            }
        } 
    }
}

