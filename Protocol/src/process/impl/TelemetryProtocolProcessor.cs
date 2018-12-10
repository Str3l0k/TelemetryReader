using Telemetry.Utilities;
using System;
using Telemetry.Read;

namespace Telemetry.Process
{
    public delegate void DataProcessed<T>(T data);

    public class TelemetryProtocolProcessor<T> : IGameDataProcessor
    {
        // event after conversion
        public event DataProcessed<T> OnDataProcessed;


        public Action<T> processedCallback;
        private T structure = Activator.CreateInstance<T>();
        

        //private Games.R3E.Data.Structure structure = new Games.R3E.Data.Structure();

        public void ProcessData(GameData data)
        {
            //Debug.WriteLine("Processing data");

            var bytes = data.RawData;
            StructMarshal.MarshalRawDataToStruct(bytes, ref structure);

            //Debug.WriteLine(structure.Gear);

            processedCallback?.Invoke(structure);
        }
    }
}
