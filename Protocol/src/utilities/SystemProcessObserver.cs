using System.Diagnostics;
using System.Threading;

namespace Telemetry.Utilities
{
    public delegate void ProcessFound();
    public delegate void ProcessExited();

    public class SystemProcessObserver
    {
        /* events */
        public event ProcessFound OnProcessFound;
        public event ProcessExited OnProcessExited;

        /* properties */
        private readonly string ProcessName;
        private Thread searchThread;
        private bool processFound = false;
        private volatile bool threadRunning = false;
        public int searchDelay = 5000;

        /* constructor */
        public SystemProcessObserver(string processName)
        {
            this.ProcessName = processName;
        }

        /* control */
        public void Observe()
        {
            Stop();

            searchThread = new Thread(new ThreadStart(Search));
            searchThread.Start();
        }

        public void Stop()
        {
            if (searchThread != null)
            {
                threadRunning = false;
                searchThread = null;
            }
        }

        /* search loop */
        private void Search()
        {
            threadRunning = true;

            while (!processFound && threadRunning)
            {
                Debug.WriteLine($"Checking for process {ProcessName}.");

                var processes = System.Diagnostics.Process.GetProcessesByName(ProcessName);

                if (processes.Length > 0)
                {
                    Debug.WriteLine($"Process {0} found.", ProcessName);
                    processFound = true;

                    processes[0].EnableRaisingEvents = true;
                    processes[0].Exited += (sender, e) => { OnProcessExited(); };
                    OnProcessFound?.Invoke();
                }

                Thread.Sleep(searchDelay);
            }
        }
    }
}
