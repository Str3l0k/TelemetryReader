using Games;
using System;
using Telemetry.Connection;
using Telemetry.Protocol.Datapool;
using Telemetry.Read;
using TelemetryReader.Read;

namespace Telemetry.Processing
{
    public static class GamesExtension
    {
        public static IGameDataReader DataReaderForGame(this GameDict games, GameID ID)
        {
            switch (ID)
            {
                case GameID.RaceRoomExperience:
                    return new SharedMemoryDataReader(
                        Games.R3E.SharedMemory.Name,
                        Games.R3E.SharedMemory.Size);
                case GameID.ProjectCars2:
                    throw new NotImplementedException();
                case GameID.DirtRally:
                    return new UDPDataReader(20777, Games.Codemasters.DataInfo.ExtraData3Size);
                default:
                    return null;
            }
        }

        public static IGameDataProcessor DataProcessForGame(this GameDict games, GameID ID, ITransmitConnection connection)
        {
            switch (ID)
            {
                case GameID.RaceRoomExperience:
                    return new RaceRoomDataProcessor(connection);
                case GameID.ProjectCars2:
                    throw new NotImplementedException();
                case GameID.DirtRally:
                    return new DirtRallyDataReader(connection);
                default:
                    return null;
            }
        }

        public static GameDataWorker WorkerForGame(
            this GameDict games,
            GameID gameID,
            ITransmitConnection connection,
            Action<TelemetryDatapool> processCallback)
        {
            var dataReader = games.DataReaderForGame(gameID);
            var dataProcessor = games.DataProcessForGame(gameID, connection);
            dataProcessor.ProcessedCallback += processCallback;

            return new GameDataWorker(dataReader, dataProcessor);
        }
    }
}
