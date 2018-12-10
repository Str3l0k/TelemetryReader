using R3EData.Data;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using TelemetryReader.src.protocol;
using TelemetryReaderWpf.src.reader;

namespace TelemetryReaderWpf.src
{
    public delegate void DataAvailable(object sender, EventArgs e);

    public class Worker
    {
        private int workerID;

        private Thread workerThread;
        private bool working;

        public Reader reader { get; set; }
        private Connection connection;

        public bool dataHasBecomeAvailable { get; private set; }
        public event DataAvailable onDataAvailable;

        /* constructor */
        public Worker(Connection connection, int ID)
        {
            this.connection = connection;

            createThread();
            working = false;

            workerID = ID;

            connection.device.reset();
        }

        public bool dataAvailable()
        {
            return reader != null && reader.dataAvailable();
        }

        public void start()
        {
            if (workerThread != null)
            {
                stop();
            }

            createThread();

            dataHasBecomeAvailable = false;
            working = true;
            workerThread.Start();

            connection.device.activate();
        }

        public void stop()
        {
            working = false;

            if (workerThread != null)
            {
                workerThread.Abort();
                workerThread = null;

                connection.device.reset();

                dataHasBecomeAvailable = false;
            }
        }

        public void changeReader(Reader newReader)
        {
            stop();
            reader = newReader;
        }

        public void changeReaderAndRestart(Reader newReader)
        {
            changeReader(newReader);
            start();
        }

        private void createThread()
        {
            workerThread = new Thread(new ThreadStart(loop));
        }

        private void loop()
        {
            while (connection.device.enabled && connection.device.active && working)
            {
                if (reader != null && reader.dataAvailable())
                {
                    if (!dataHasBecomeAvailable && onDataAvailable != null)
                    {
                        dataHasBecomeAvailable = true;
                        onDataAvailable(this, EventArgs.Empty);
                    }
                    else
                    {
                        dataHasBecomeAvailable = false;
                    }

                    // read
                    SendData sendData = reader.Read();

                    // send
                    connection.send(sendData.data, sendData.size);

                    // sleep
                    Thread.Sleep(connection.getDelay());
                }
                else
                {
                    // sleep a bit longer while no data available
                    Thread.Sleep(500);
                    Debug.WriteLine("Worker with ID " + workerID + " waiting for data.");
                }
            }
        }
    }
}
