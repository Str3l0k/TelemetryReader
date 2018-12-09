using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public static class GameInformation
    {
        /* Process names */
        public static class Processes
        {
            public static string[] AssettoCorsaProcesses = { "AssettoCorsa" };
            public static string[] AssettoCorsaCompetezioneProcesses = { "AssettoCorsaCompetezione" };
            public static string[] RaceRoomExperienceProcesses = { "RRRE", "RRRE64" };
            public static string[] GTR2Processes = { "GTR2" };
            public static string[] ProjectCarsProcesses = { "pCars", "pCars64" };
            public static string[] ProjectCars2Processes = { "pCars2Gld", "pCars2", "pCARS2AVX", "pCars264" };
            public static string[] Race07Processes = { "Race_Steam" };
            public static string[] iRacingProcesses = { "iRacingSim", "iRacingSim64", "iRacingSimDX11", "iRacingSim64DX11" };
            public static string[] rFactorProcesses = { "rFactor" };
            public static string[] rFactor2Processes = { "rFactor2" };
            public static string[] GameStockCarProcesses = { "" }; // TODO
            public static string[] EuroTruckSimulator2Processes = { }; // TODO
            public static string[] DirtRallyProcesses = { "drt" };
            public static string[] F12018Processes = { }; // TODO
            public static string[] AmericanTrucksimulatorProcesses = { }; // TODO
            public static string[] AutomobilistaProcesses = { }; // TODO
        }
    }

    public enum GameID : int
    {
        AssettoCorsa = 0xA001,
        AssettoCorsaCompetezione = 0xA002,
        RaceRoomExperience = 0xA003,
        GTR2 = 0xA004,
        ProjectCars = 0xA005,
        ProjectCars2 = 0xA006,
        Race07 = 0xA007,
        iRacing = 0xA008,
        rFactor = 0xA009,
        rFactor2 = 0xA00A,
        GameStockCar = 0xA00B,
        EuroTruckSimulator2 = 0xA00C,
        DirtRally = 0xA00D,
        F12018 = 0xA00E,
        AmericanTruckSimulator = 0xA00F,
        BeamNG = 0xA010,
        Automobilista = 0xA011
    }
}
