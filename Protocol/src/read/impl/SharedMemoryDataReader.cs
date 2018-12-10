using System.IO.MemoryMappedFiles;

namespace Telemetry.Read
{
    public class SharedMemoryDataReader : IGameDataReaderDisposable
    {
        /* properties */
        private readonly string memoryMappedFileName;
        private readonly int memoryMappedFileSize;

        /* mmf/shared memory data */
        private readonly byte[] MemoryMappedFileBuffer;
        private MemoryMappedFile MemoryMappedFile;
        private MemoryMappedViewAccessor MemoryMappedFileAccessor;

        /* constructor */
        public SharedMemoryDataReader(string memoryFileName, int memoryFileSize)
        {
            this.memoryMappedFileName = memoryFileName;
            this.memoryMappedFileSize = memoryFileSize;
            this.MemoryMappedFileBuffer = new byte[memoryFileSize];
        }

        /* IGameDataReader */
        public bool DataReady
        {
            get
            {
                try
                {
                    MemoryMappedFile = MemoryMappedFile.OpenExisting(memoryMappedFileName);
                    MemoryMappedFileAccessor = MemoryMappedFile.CreateViewAccessor();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool DataAvailable => MemoryMappedFile != null && (MemoryMappedFileAccessor?.CanRead ?? false);

        public GameData ReadData()
        {
            MemoryMappedFileAccessor.ReadArray(0, MemoryMappedFileBuffer, 0, memoryMappedFileSize);
            return new GameData(MemoryMappedFileBuffer);
        }

        public void Shutdown()
        {
            MemoryMappedFileAccessor.Dispose();
            MemoryMappedFile.Dispose();

            MemoryMappedFileAccessor = null;
            MemoryMappedFile = null;
        }
    }
}
