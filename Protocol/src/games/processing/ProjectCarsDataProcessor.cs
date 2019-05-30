using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemetry.Connection;
using Telemetry.Protocol;
using Telemetry.Protocol.Datapool;
using Telemetry.Protocol.Values;
using static Games.ProjectCars.Data;

namespace Telemetry.Processing
{
    public class ProjectCarsDataProcessor : TelemetryProtocolProcessor<Structure>
    {
        public ProjectCarsDataProcessor(ITransmitConnection connection) : base(connection) { }

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

        internal override void WriteValuesIntoDatapool(Structure dataStructure, TelemetryDatapool datapool)
        {
            WriteCarValues(dataStructure, datapool.car);
        }

        private void WriteCarValues(Structure dataStructure, Car car)
        {
            car.Gear = dataStructure.Gear;
            car.Speed = dataStructure.Speed;

            car.RPM = dataStructure.Rpm;
            car.RPMMax = dataStructure.MaxRPM;
            car.CalculateRPMPercentage();

            car.FuelLevel = dataStructure.FuelLevel;
            car.FuelCapacity = dataStructure.FuelCapacity;
            car.CalculateFuelPercentage();
        }
    }
}
