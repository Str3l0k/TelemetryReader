using TelemetryReader.src.protocol.datapool.categories;

namespace TelemetryReader.src.protocol
{
    class TelemetryValues
    {
        private IDataWriter dataWriter;

        internal Car Car { get; }
        internal Driver Driver { get; }
        internal Session Session { get; }

        TelemetryValues(IDataWriter dataWriter)
        {
            this.dataWriter = dataWriter;

            Car = new Car(dataWriter);
            Driver = new Driver(dataWriter);
            Session = new Session(dataWriter);
        }
    }
}
