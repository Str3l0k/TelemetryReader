//using System.Net.Sockets;

//namespace TelemetryReaderWpf.src
//{
//    public class Connection
//    {
//        public UdpClient udpSocket { get; private set; }
//        public Device device { get; private set; }

//        public Connection(Device device)
//        {
//            this.device = device;
//            udpSocket = new UdpClient();         
//        }

//        public void send(byte[] data)
//        {
//            send(data, data.Length);
//        }

//        public void send(byte[] data, int lenght)
//        {
//            udpSocket.Send(data, lenght, device.ipAddress);
//        }

//        public int getDelay()
//        {
//            return device.delay;
//        }
//    }
//}
