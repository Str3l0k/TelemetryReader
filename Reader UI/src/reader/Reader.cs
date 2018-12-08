using TelemetryReader.src.protocol;

namespace TelemetryReaderWpf.src.reader
{
    public interface Reader
    {
        bool dataAvailable();
        SendData Read();
        void shutdown();
    }
}
