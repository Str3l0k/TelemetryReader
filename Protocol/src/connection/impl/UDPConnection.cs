using System.Net;
using System.Net.Sockets;

namespace Telemetry.Connection
{
    public class UDPConnection : IConnection
    {
        // properties
        private readonly IPEndPoint ipEndPoint;
        private readonly UdpClient udpClient;

        #region (con/de)structor
        public UDPConnection(IPEndPoint ip)
        {
            this.ipEndPoint = ip;
            this.udpClient = new UdpClient();
        }

        ~UDPConnection()
        {
            this.udpClient?.Close();
        }
        #endregion

        #region implementation
        public void Send(ref byte[] data)
        {
            udpClient.Send(data, data.Length, ipEndPoint);
        }

        public byte[] Receive()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
