//using System;
//using System.Linq;
//using System.Net;
//using System.Net.Sockets;
//using TelemetryReader.src.protocol;
//using TelemetryReaderWpf.src.reader;

//namespace TelemetryReader.src.reader.impl
//{
//    public abstract class UDPDataReceiver<T> : GameReader<T>
//    {
//        private UdpClient receiveClient;
//        private IPEndPoint ipEndPoint;

//        private SendData sendData;
//        private SendData receivedData;

//        /* constructor */
//        public UDPDataReceiver(int port, int size) : base()
//        {
//            ipEndPoint = new IPEndPoint(IPAddress.Any, port);
//            receiveClient = new UdpClient();
//            receiveClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
//            receiveClient.Client.Bind(ipEndPoint);
            
//            this.sendData = new SendData(size);
//            this.receivedData = new SendData(size);
//        }

//        public override bool dataAvailable()
//        {
//            byte[] received = receiveClient.Receive(ref ipEndPoint);
//            receivedData.data = received;
//            receivedData.size = received.Length;

//            return receivedData.size > 0;
//        }

//        public override SendData Read()
//        {
//            marshalDataToStruct(receivedData);
//            writeValues(data);

//            return protocolPacketData.getData(valueDictionary.Values);
//        }

//        public override void shutdown()
//        {
//            receiveClient.Close();
//        }
//    }
//}
