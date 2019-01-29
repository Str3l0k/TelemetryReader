using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using Telemetry.Read;

namespace TelemetryReader.Read
{
    public class UDPDataReader : IGameDataReaderDisposable
    {
        /* properties */
        private IPEndPoint ipEndPoint;
        private readonly UdpClient receiveClient;
        private readonly byte[] dataBuffer;
        
        /* construction */
        public UDPDataReader(int port, int size)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Loopback, port);
            receiveClient = new UdpClient();
            receiveClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            receiveClient.Client.Bind(ipEndPoint);

            this.dataBuffer = new byte[size];
        }

        #region IGameDataReader interface
        public bool DataReady => DataAvailable;

        public bool DataAvailable
        {
            get
            {
                //Debug.WriteLine($"Before receive {new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()}");
                byte[] received = receiveClient.Receive(ref ipEndPoint);
                //Debug.WriteLine($"After receive {new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()}");

                if (received.Length > dataBuffer.Length)
                {
                    return false;
                }

                Buffer.BlockCopy(received, 0, dataBuffer, 0, received.Length);

                return true;
            }
        }

        public GameData ReadData()
        {
            return new GameData(dataBuffer);
        }        

        public void Shutdown()
        {
            receiveClient.Close();
        }
        #endregion
    }
}
