using System.Collections.Generic;

namespace Games
{
    public class GameDict
    {
        /* games dict */
        public Dictionary<int, Game> Dictionary { get; private set; }
        public Game[] AsArray
        {
            get
            {
                var array = new Game[Dictionary.Count];
                Dictionary.Values.CopyTo(array, 0);
                return array;
            }
        }

        /* constructor */
        public GameDict()
        {
            Dictionary = new Dictionary<int, Game>();
            InitGames();
        }

        private void InitGames()
        {
            Dictionary.Add((int)GameID.AssettoCorsa,
                new Game(GameID.AssettoCorsa, GameInformation.Processes.AssettoCorsaProcesses));

            Dictionary.Add((int) GameID.RaceRoomExperience,
                new Game(GameID.RaceRoomExperience, GameInformation.Processes.RaceRoomExperienceProcesses));

            Dictionary.Add((int) GameID.ProjectCars2,
                new Game(GameID.ProjectCars2, GameInformation.Processes.ProjectCars2Processes));

            Dictionary.Add((int)GameID.DirtRally,
                new Game(GameID.DirtRally, GameInformation.Processes.DirtRallyProcesses));
        }
    }
}
