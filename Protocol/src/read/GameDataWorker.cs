using System;
using System.Diagnostics;
using System.Threading;

namespace Protocol
{
    public class GameDataWorker
    {
        /* data objects */
        private readonly IGameDataReader DataReader;
        private readonly IGameDataProcessor DataProcessor;

        /* properties */
        public int ReadyWaitDelay = 100;
        public int WorkDelay = 1000 / 60; // = 16 (ms) for roughly 60 updates per second

        /* */
        private Thread WorkerThread;
        private bool working = false;

        /* computed properties */
        private bool Ready => DataReader != null && DataReader.DataReady;

        /* constructor */
        public GameDataWorker(IGameDataReaderDisposable dataReader, IGameDataProcessor dataProcessor)
        {
            this.DataReader = dataReader;
            this.DataProcessor = dataProcessor;
        }

        /* control access */
        public void Start()
        {
            if (WorkerThread != null) {
                Stop();
            }

            WorkerThread = new Thread(new ThreadStart(Work));
            WorkerThread.Start();
        }

        public void Stop()
        {
            working = false;

            WorkerThread?.Abort();
            WorkerThread = null;
        }

        /* thread loop */
        private void Work()
        {
            working = true;

            // wait for ready
            while (!Ready)
            {
                Thread.Sleep(ReadyWaitDelay);
                Debug.WriteLine("Worker waiting for data ready.");
            }

            Debug.WriteLine("DataReader ready. Starting read and process.");

            while (working)
            {
                if(DataReader.DataAvailable)
                {
                    var data = DataReader.ReadData();
                    DataProcessor.ProcessData(data);
                }

                Thread.Sleep(WorkDelay);
            }
        }
    }
}
