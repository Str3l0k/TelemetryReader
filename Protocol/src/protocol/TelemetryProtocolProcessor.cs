using System;
using System.Collections.Generic;
using Telemetry.Process;
using Telemetry.Processing.Calculation;
using Telemetry.Protocol.Datapool;
using Telemetry.Protocol.Transmission;
using Telemetry.Read;
using Telemetry.Send;
using Telemetry.Utilities;

namespace Telemetry.Protocol
{
    public abstract class TelemetryProtocolProcessor<T> : IGameDataProcessor
    {
        // event after conversion
        public Action<TelemetryDatapool> processedCallback;

        /* submodules */
        protected readonly List<ITelemetryCalculation> calculations = new List<ITelemetryCalculation>();
        protected IConnection connection;
        private ProtocolPacketConverter packetConverter;
        private ProtocolPacketHeader packetHeader;

        /* data properties */
        protected T dataStructure = Activator.CreateInstance<T>();
        protected readonly TelemetryDatapool datapool = new TelemetryDatapool(false);

        /* constructor */
        protected TelemetryProtocolProcessor()
        {
            InitValues();
            packetConverter = new ProtocolPacketConverter(skipUnchangedValues: true);
            packetHeader = new ProtocolPacketHeader(2);
        }

        protected TelemetryProtocolProcessor(IConnection connection) : this()
        {
            this.connection = connection;
        }
        
        /* */
        public void AddCalculation(ITelemetryCalculation calculation)
        {
            calculations.Add(calculation);
        }

        public void RemoveCalculation(ITelemetryCalculation calculation)
        {
            calculations.Remove(calculation);
        }

        /* processing interface */
        public void ProcessData(GameData data)
        {
            ConvertRawDataToStructure(data);
            WriteValuesIntoDatapool();

            // Execute calculations
            calculations.ForEach((calculation) =>
            {
                calculation.Calculate(datapool);
            });
            
            if (connection != null)
            {
                // convert datapool to raw data
                var valueArray = datapool.ValueArray;
                var byteData = packetConverter.GetBytesFromValues(valueArray);
                packetHeader.ValueCount = (short)valueArray.Length;

                // assemble complete packet data
                var sendData = new byte[byteData.Length + packetHeader.HeaderData.Length];
                Buffer.BlockCopy(packetHeader.HeaderData, 0, sendData, 0, packetHeader.HeaderData.Length);
                Buffer.BlockCopy(byteData, 0, sendData, packetHeader.HeaderData.Length, byteData.Length);

                // transmit packet through connection
                connection.Send(sendData);
            }

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
