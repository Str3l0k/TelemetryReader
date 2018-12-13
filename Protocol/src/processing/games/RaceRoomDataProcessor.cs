using Telemetry.Protocol;
using Telemetry.Protocol.Values;

namespace Telemetry.Processing
{
    public class RaceRoomDataProcessor : TelemetryProtocolProcessor<Games.R3E.Data.Structure>
    {
        internal override void InitValues()
        {
            datapool.InitValues(
                TelemetryValues.Car.PowerTrain.Gear,
                TelemetryValues.Car.PowerTrain.RPM,
                TelemetryValues.Car.PowerTrain.RPMMax,
                TelemetryValues.Car.PowerTrain.RPMPercentage,
                TelemetryValues.Car.Physics.Speed
                );
        }

        internal override void WriteValuesIntoDatapool()
        {
            datapool.car.Gear = dataStructure.Gear;
            datapool.car.Speed = dataStructure.CarSpeed;
            datapool.car.RPM = dataStructure.EngineRps;
            datapool.car.RPMMax = dataStructure.MaxEngineRps;
        }
    }
}
