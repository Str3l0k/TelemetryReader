namespace Telemetry.Connection
{
    public interface ITransmitConnection
    {
        void Send(ref byte[] data);
    }

    public interface IReceiveConnection
    {
        byte[] Receive();
    }

    public interface IConnection: ITransmitConnection, IReceiveConnection
    {

    }
}
