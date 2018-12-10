using Games;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace TelemetryReaderWpf.src.game.search
{
    public delegate void GameFound(object sender, EventArgs e);
    public delegate void GameExited(object sender, EventArgs e);

    public class GameSearcher
    {
        /* all available games */
        public List<Game> games;

        /* search thread */
        private Thread searchThread;

        /* game found state */
        public Game lastFoundGame { get; private set; }
        public bool gameFound { get; private set; }

        /* game events */
        public event GameFound onGameFound;
        public event GameExited onGameExited;

        /* constructor */
        public GameSearcher(params Game[] games)
        {
            this.games = new List<Game>();
            this.games.AddRange(games);

            gameFound = false;
        }

        private void createNewThread()
        {
            searchThread = new Thread(new ThreadStart(search));
        }

        public void start()
        {
            createNewThread();
            gameFound = false;

            searchThread.Start();
        }

        public void stop()
        {
            if (searchThread != null)
            {
                searchThread.Abort();
                searchThread = null;
            }
        }

        private void search()
        {
            while (!gameFound)
            {
                Debug.WriteLine("=========================================================");
                Debug.WriteLine("Searching for game .EXE");

                // TODO longer time

                foreach (Game game in games)
                {
                    foreach (string gameExe in game.ProcessNames)
                    {
                        Process[] proc = Process.GetProcessesByName(gameExe);

                        if (proc.Length > 0)
                        {
                            //add the restart of searching as
                            proc[0].EnableRaisingEvents = true;
                            proc[0].Exited += (sender, e) => { onGameExited(this, EventArgs.Empty); };

                            gameFound = true;

                            lastFoundGame = game;

                            break;
                        }
                    }
                }

                Thread.Sleep(2500);
            }

            if (gameFound && onGameFound != null)
            {
                onGameFound(this, EventArgs.Empty);
            }
        }
    }
}