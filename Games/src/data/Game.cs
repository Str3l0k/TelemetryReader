using Protocol;

namespace Games
{
    public class Game
    {
        /* game data */
        public GameID ID { get; private set; }
        public string Name { get; private set; }
        public string[] ProcessNames { get; private set; }

        /* game specific Reader */
        public IGameDataReader reader { get; private set; }

        /* constructor */
        public Game(GameID id, IGameDataReader reader, params string[] processNames)
        {
            this.Name = Name;
            this.ID = ID;
            this.reader = reader;
            this.ProcessNames = processNames;
        }
    }
}
