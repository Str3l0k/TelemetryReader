using System.Collections.Generic;
using TelemetryReader.src.protocol.games;
using TelemetryReader.src.protocol.games.codemasters;
using TelemetryReader.src.protocol.games.race;
using TelemetryReader.src.protocol.games.rfactor2;
using TelemetryReaderWpf.src.game;

namespace TelemetryReaderWpf.src.context
{
    public class GameContext
    {
        public const int readerVersion = 221;

        /* Game data */
        /* IDs */
        public const int AssettoCorsaID = 0xA0A0A;
        public const int RaceRoomExperienceID = 0xB0B0B;
        public const int GTR2ID = 0xC0C0C;
        public const int ProjectCarsID = 0xD0D0D;
        public const int ProjectCars2ID = 0xDADAD;
        public const int Race07ID = 0xE0E0E;
        public const int iRacingID = 0xF0F0F;
        public const int rFactorID = 0xAA0AA;
        public const int rFactor2ID = 0xBB0BB;
        public const int GameStockCarID = 0xCC0CC;
        public const int EuroTruckSimulatorID = 0xDD0DD;
        public const int DirtRallyID = 0xFF0FF;

        /* gamesIDMap */
        public Game AssettoCorsa;
        public Game RaceRoomExperience;
        public Game GTR2;
        public Game ProjectCars;
        public Game ProjectCars2;
        public Game Race07;
        public Game iRacing;
        public Game rFactor;
        public Game rFactor2;
        public Game GameStockCar;
        public Game EuroTruckSimulator;
        public Game DirtRally;

        public SortedDictionary<int, Game> gameIDsList { get; private set; }
        public SortedDictionary<string, Game> gameNamesList { get; private set; }

        public GameContext()
        {
            /* create game objects */
            AssettoCorsa = new Game("Assetto Corsa", AssettoCorsaID, new AssettoCorsaReader(), "AssettoCorsa");
            RaceRoomExperience = new Game("RaceRoom Experience", RaceRoomExperienceID, new R3EReader(), "RRRE", "RRRE64");
            GTR2 = new Game("GTR 2", GTR2ID, new GTR2Reader(), "GTR2");
            ProjectCars = new Game("Project CARS (2)", ProjectCarsID, new ProjectCarsReader(), "pCars", "pCars64", "pCars2Gld", "pCars2", "pCARS2AVX", "pCars264");
            //ProjectCars2 = new Game("Project CARS 2", ProjectCarsID, new ProjectCars2Reader(), "pCars2Gld", "pCars2", "pCARS2AVX", "pCars264");
            Race07 = new Game("Race 07", Race07ID, new Race07Reader(), "Race_Steam");
            iRacing = new Game("iRacing", iRacingID, new iRacingReader(), "iRacingSim", "iRacingSim64", "iRacingSimDX11", "iRacingSim64DX11");
            //rFactor = new Game("rFactor", rFactorID, new SharedMemoryReader("", 0, rFactorID, readerVersion), "rFactor"); // TODO
            rFactor2 = new Game("rFactor2", rFactor2ID, new rFactor2Reader(), "rFactor2");
            //GameStockCar = new Game("Game Stock Car", GameStockCarID, new SharedMemoryReader("", 0, GameStockCarID, readerVersion), "GameStockCar"); // TODO
            //EuroTruckSimulator = new Game("Euro Truck Simulator", EuroTruckSimulatorID, new SharedMemoryReader("", 0, EuroTruckSimulatorID, readerVersion), "ETS2"); // TODO
            DirtRally = new Game("Dirt Rally", DirtRallyID, new DirtRallyReader(20777), "drt"); // TODO

            gameIDsList = new SortedDictionary<int, Game>();
            gameNamesList = new SortedDictionary<string, Game>();

            ///* add games */
            gameIDsList.Add(AssettoCorsa.ID, AssettoCorsa);
            gameIDsList.Add(RaceRoomExperience.ID, RaceRoomExperience);
            gameIDsList.Add(GTR2.ID, GTR2);
            gameIDsList.Add(ProjectCars.ID, ProjectCars);
            //gameIDsList.Add(ProjectCars.ID, ProjectCars2);
            gameIDsList.Add(Race07.ID, Race07);
            gameIDsList.Add(iRacing.ID, iRacing);
            gameIDsList.Add(rFactor2.ID, rFactor2);
            gameIDsList.Add(DirtRally.ID, DirtRally);

            gameNamesList.Add(AssettoCorsa.name, AssettoCorsa);
            gameNamesList.Add(RaceRoomExperience.name, RaceRoomExperience);
            gameNamesList.Add(GTR2.name, GTR2);
            gameNamesList.Add(ProjectCars.name, ProjectCars);
            //gameNamesList.Add(ProjectCars2.name, ProjectCars2);
            gameNamesList.Add(Race07.name, Race07);
            gameNamesList.Add(iRacing.name, iRacing);
            gameNamesList.Add(rFactor2.name, rFactor2);
            gameNamesList.Add(DirtRally.name, DirtRally);
        }
    }
}
