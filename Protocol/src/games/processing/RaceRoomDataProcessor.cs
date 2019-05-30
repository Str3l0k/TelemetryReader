using Telemetry.Protocol;
using Telemetry.Protocol.Values;
using Telemetry.Connection;
using Telemetry.Protocol.Datapool;

namespace Telemetry.Processing
{
    public class RaceRoomDataProcessor : TelemetryProtocolProcessor<Games.R3E.Data.Structure>
    {
        public RaceRoomDataProcessor(ITransmitConnection connection) : base(connection) { }

        internal override void InitValues(TelemetryDatapool datapool)
        {
            datapool.InitValues(
                TelemetryValues.Car.PowerTrain.Gear,
                TelemetryValues.Car.PowerTrain.RPM,
                TelemetryValues.Car.PowerTrain.RPMMax,
                TelemetryValues.Car.PowerTrain.RPMPercentage,
                TelemetryValues.Car.Physics.Speed,
                TelemetryValues.Car.Fuel.FuelLevel,
                TelemetryValues.Car.Fuel.FuelPercentage,
                TelemetryValues.Car.Fuel.FuelCapacity
                );
        }

        internal override void WriteValuesIntoDatapool(Games.R3E.Data.Structure dataStructure, TelemetryDatapool datapool)
        {
            datapool.car.Gear = dataStructure.Gear;
            datapool.car.Speed = dataStructure.CarSpeed;

            datapool.car.RPM = dataStructure.EngineRps;
            datapool.car.RPMMax = dataStructure.MaxEngineRps;
            datapool.car.CalculateRPMPercentage();

            datapool.car.FuelLevel = dataStructure.FuelLeft;
            datapool.car.FuelCapacity = dataStructure.FuelCapacity;
            datapool.car.CalculateFuelPercentage();
        }
    }
}
