using Telemetry.Read;

namespace Telemetry.Process
{
    public interface IGameDataProcessor
    {
        void ProcessData(GameData data);
    }
}
