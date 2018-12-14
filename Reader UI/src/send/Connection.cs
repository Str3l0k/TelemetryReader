using System.Net;
using System.Net.Sockets;

namespace TelemetryReaderWpf.src
{
    public class Connection
    {
        private readonly UdpClient UdpSocket;
        private readonly IPEndPoint IPEndPoint;

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
            UdpSocket.Send(data, lenght, IPEndPoint);
        }
    }
}
