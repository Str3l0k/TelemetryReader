using System;

namespace Games
{
    public class Game
    {
        /* game data */
        public GameID ID { get; private set; }
        public string[] ProcessNames { get; private set; }

        /* computed properties */
        public string Name => Enum.GetName(ID.GetType(), ID);
        public int gameID => (int)ID;

        /* constructor */
        public Game(GameID id, params string[] processNames)
        {
            this.ID = id;
            this.ProcessNames = processNames;
        }
    }
}
