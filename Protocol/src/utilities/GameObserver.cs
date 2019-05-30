using Games;
using System.Collections.Generic;

namespace Telemetry.Utilities
{
    public delegate void GameFound(Game game);
    public delegate void GameExited(Game game);

    public class GameObserver
    {
        /* properties */
        private Game[] games;
        private List<SystemProcessObserver> processObservers;

        /* events */
        public event GameFound OnGameFound;
        public event GameExited OnGameExited;

        /* constructor */
        public GameObserver(Game[] games)
        {
            this.games = games;
            this.processObservers = new List<SystemProcessObserver>();
        }

        /* control */
        public void Start()
        {
            foreach (Game game in games)
            {
                foreach (string gameProcessName in game.ProcessNames)
                {
                    var processObserver = new SystemProcessObserver(gameProcessName);

                    processObserver.OnProcessFound += () =>
                    {
                        OnGameFound(game);
                    };

                    processObserver.OnProcessExited += () =>
                    {
                        OnGameExited(game);
                    };

                    processObservers.Add(processObserver);
                }
            }

            foreach (SystemProcessObserver observer in processObservers)
            {
                observer.Observe();
            }
        }

        public void Stop()
        {
            foreach (SystemProcessObserver observer in processObservers)
            {
                observer.Stop();
            }
        }
    }
}
