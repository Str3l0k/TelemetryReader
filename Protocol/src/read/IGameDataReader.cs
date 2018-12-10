namespace Telemetry.Read
{
    public interface IGameDataReader
    {
        // state
        bool DataReady { get; }
        bool DataAvailable { get; }

        // data access
        GameData ReadData();
    }

    public interface IGameDataReaderDisposable: IGameDataReader
    {
        // close
        void Shutdown();
    }
}
