using System.Collections.Generic;

namespace Games
{
    public class GameDict
    {
        /* games dict */
        public Dictionary<int, Game> dictionary { get; private set; }
        public Game[] asArray
        {
            get
            {
                var array = new Game[dictionary.Count];
                dictionary.Values.CopyTo(array, 0);
                return array;
            }
        }

        /* constructor */
        public GameDict()
        {
            dictionary = new Dictionary<int, Game>();
            InitGames();
        }

        private void InitGames()
        {
            dictionary.Add((int)GameID.AssettoCorsa,
                new Game(GameID.AssettoCorsa, GameInformation.Processes.AssettoCorsaProcesses));

            dictionary.Add((int) GameID.RaceRoomExperience,
                new Game(GameID.RaceRoomExperience, GameInformation.Processes.RaceRoomExperienceProcesses));

            dictionary.Add((int) GameID.ProjectCars2,
                new Game(GameID.ProjectCars2, GameInformation.Processes.ProjectCars2Processes));
        }
    }
}
