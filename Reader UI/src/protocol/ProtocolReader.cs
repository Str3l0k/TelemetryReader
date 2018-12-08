using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelemetryReader.src.protocol;
using TelemetryReaderWpf.src.reader;

namespace TelemetryReader.src.protocol
{
    public abstract class GameReader<T> : ProtocolDataConverter<T>, Reader
    {
        internal ProtocolPacketData protocolPacketData;

        public GameReader() : base()
        {
            this.protocolPacketData = new ProtocolPacketData();
        }

        public abstract bool dataAvailable();

        public abstract SendData Read();

        public abstract void shutdown();
    
        protected SendData convertValuesToData()
        {
            return protocolPacketData.getData(valueDictionary.Values);
        }
    }

    internal class ProtocolReader : Reader
    {
        /* parts for sending */
        private ProtocolPacketHeader protocolHeader;
        private ProtocolPacketData protocolPacket;

        /* reader to get the data */
        public Reader reader { get; set; }

        /* packet number */
        public Int64 packetCounter;

        /* buffer */
        private byte[] protocolBuffer;
        private SendData sendData;

        /* constructor */
        public ProtocolReader(int protocolID)
        {
            this.protocolHeader = new ProtocolPacketHeader(1);
            this.protocolHeader.ProtocolID = protocolID;
            this.protocolPacket = new ProtocolPacketData();
            this.protocolBuffer = new byte[4096];
            this.sendData = new SendData();
            this.sendData.data = protocolBuffer;
        }

        public bool dataAvailable()
        {
            return reader != null && reader.dataAvailable();
        }

        public SendData Read()
        {
            // read game data
            SendData gameData = reader.Read();
            protocolHeader.ValueCount = gameData.count;
            
            // copy header
            protocolHeader.PacketNumber = packetCounter++;
            Buffer.BlockCopy(protocolHeader.headerBuffer, 0, protocolBuffer, 0, protocolHeader.headerBuffer.Length);

            // copy data
            Buffer.BlockCopy(gameData.data, 0, protocolBuffer, protocolHeader.headerBuffer.Length, gameData.size);
            sendData.size = protocolHeader.headerBuffer.Length + gameData.size;

            return sendData;
        }

        public void shutdown()
        {
            reader.shutdown();
        }
    }
}
