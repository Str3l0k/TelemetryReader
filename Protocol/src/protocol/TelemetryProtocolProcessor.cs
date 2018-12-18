using System;
using System.Collections.Generic;
using Telemetry.Process;
using Telemetry.Processing.Calculation;
using Telemetry.Protocol.Datapool;
using Telemetry.Read;
using Telemetry.Utilities;

namespace Telemetry.Protocol
{
    public abstract class TelemetryProtocolProcessor<T> : IGameDataProcessor
    {
        // event after conversion
        public Action<TelemetryDatapool> processedCallback;

        /* properties */
        protected T dataStructure = Activator.CreateInstance<T>();
        protected readonly TelemetryDatapool datapool = new TelemetryDatapool(false);
        protected readonly List<ITelemetryCalculation> calculations = new List<ITelemetryCalculation>();

        /* constructor */
        protected TelemetryProtocolProcessor()
        {
            InitValues();
        }

        /* processing interface */
        public void ProcessData(GameData data)
        {
            ConvertRawDataToStructure(data);
            WriteValuesIntoDatapool();
            // TODO Execute calculations
            calculations.ForEach((calculation) =>
            {
                calculation.Calculate(datapool);
            });
            // TODO convert datapool to raw data
            // TODO assemble complete packet data
            // TODO transmit packet through connection

            processedCallback?.Invoke(datapool);
        }

        private void ConvertRawDataToStructure(GameData data)
        {
            var bytes = data.RawData;
            StructMarshal.MarshalRawDataToStruct(bytes, ref dataStructure);
        }

        /* specific implementation per data structure */
        internal abstract void InitValues();

        internal abstract void WriteValuesIntoDatapool();
    }
}
