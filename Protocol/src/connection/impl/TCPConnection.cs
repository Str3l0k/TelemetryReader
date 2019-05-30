namespace Telemetry.Connection
{
    public class TCPConnection: IConnection
    {
        public TCPConnection()
        {

        }

        public void Send(ref byte[] data)
        {
            throw new System.NotImplementedException();
        }
        
        public byte[] Receive()
        {
            throw new System.NotImplementedException();
        }
    }
}
