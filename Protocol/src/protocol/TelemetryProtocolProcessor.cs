using System;
using Telemetry.Process;
using Telemetry.Read;
using Telemetry.Utilities;

namespace Telemetry.Protocol
{
    public class TelemetryProtocolProcessor<T> : IGameDataProcessor
    {
        // event after conversion
        public Action<T> processedCallback;
        private T structure = Activator.CreateInstance<T>();

        public void ProcessData(GameData data)
        {
            var bytes = data.RawData;
            StructMarshal.MarshalRawDataToStruct(bytes, ref structure);
            processedCallback?.Invoke(structure);
        }
    }
}
