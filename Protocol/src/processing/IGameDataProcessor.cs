using System;
using Telemetry.Protocol.Datapool;
using Telemetry.Read;

namespace Telemetry.Processing
{
    public interface IGameDataProcessor
    {
        Action<TelemetryDatapool> ProcessedCallback { get; set; }

        void ProcessData(GameData data);
    }
}
