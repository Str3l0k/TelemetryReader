using System.Collections.Generic;

namespace Games
{
    public class Games
    {
        /* games dict */
        public Dictionary<GameID, Game> GameDict { get; private set; }

        /* constructor */
        public Games()
        {
            initGames();
        }

        private void initGames()
        {
            GameDict.Add(GameID.AssettoCorsa,
                new Game(GameID.AssettoCorsa, null, GameInformation.Processes.AssettoCorsaProcesses));

            GameDict.Add(GameID.RaceRoomExperience,
                new Game(GameID.RaceRoomExperience, null, GameInformation.Processes.RaceRoomExperienceProcesses));

            GameDict.Add(GameID.ProjectCars2,
                new Game(GameID.ProjectCars2, null, GameInformation.Processes.ProjectCars2Processes));
        }
    }
}
