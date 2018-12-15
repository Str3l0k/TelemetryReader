using System;
using Telemetry.Process;
using Telemetry.Protocol.Datapool;
using Telemetry.Protocol.Transmission;
using Telemetry.Read;
using Telemetry.Utilities;

namespace Telemetry.Protocol
{
    public abstract class TelemetryProtocolProcessor<T> : IGameDataProcessor
    {
        // event after conversion
        public Action<TelemetryDatapool> processedCallback;

        /* properties */
        protected readonly TelemetryDatapool datapool = new TelemetryDatapool(false);
        protected T dataStructure = Activator.CreateInstance<T>();
        
        /* constructor */
        protected TelemetryProtocolProcessor()
        {
            InitValues();
        }

        /* processing interface */
        public void ProcessData(GameData data)
        {
            var bytes = data.RawData;
            StructMarshal.MarshalRawDataToStruct(bytes, ref dataStructure);

            WriteValuesIntoDatapool();
            
            processedCallback?.Invoke(datapool);
        }

        /* specific implementation per data structure */
        internal abstract void InitValues();

        internal abstract void WriteValuesIntoDatapool();
    }
}
