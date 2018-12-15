using System.Net;
using System.Net.Sockets;

namespace TelemetryReaderWpf.src
{
    public class Connection
    {
        private readonly UdpClient UdpSocket;
        public IPEndPoint IPEndPoint { get; set; }

        public Connection()
        {
            UdpSocket = new UdpClient();
        }

        public void Send(byte[] data)
        {
            Send(data, data.Length);
        }

        public void Send(byte[] data, int lenght)
        {
            if (IPEndPoint != null)
            {
                UdpSocket.Send(data, lenght, IPEndPoint);
            }
        }
    }
}
