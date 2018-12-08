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
                new Game(GameID.AssettoCorsa, null, GameData.Processes.AssettoCorsaProcesses));

            GameDict.Add(GameID.RaceRoomExperience,
                new Game(GameID.RaceRoomExperience, null, GameData.Processes.RaceRoomExperienceProcesses));

            GameDict.Add(GameID.ProjectCars2,
                new Game(GameID.ProjectCars2, null, GameData.Processes.ProjectCars2Processes));
        }
    }
}
