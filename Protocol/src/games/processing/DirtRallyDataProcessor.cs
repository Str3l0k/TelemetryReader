using System;
using System.Diagnostics;
using Telemetry.Connection;
using Telemetry.Protocol;
using Telemetry.Protocol.Datapool;
using Telemetry.Protocol.Values;

namespace Telemetry.Processing
{
    public class DirtRallyDataReader : TelemetryProtocolProcessor<Games.Codemasters.ExtraData3>
    {
        public DirtRallyDataReader(ITransmitConnection connection) : base(connection)
        {
        }

        protected void writeCarValues(Car car, Games.Codemasters.ExtraData3 data)
        {
            car.Gear = (int) data.m_gear;
            //car.RPM = R3EReader.rpsToRPM(data.RPM); // TODO create utils
            //car.RPMMax = R3EReader.rpsToRPM(data.MaximumRPM); // TODO create utils
            car.RPM = data.RPS; // TODO create utils
            car.RPMMax = data.m_max_rps; // TODO create utils

            //car.BrakeTemperatureFL = data.TemperatureBrakeFrontLeft;
            //car.BrakeTemperatureFR = data.TemperatureBrakeFrontRight;
            //car.BrakeTemperatureRL = data.TemperatureBrakeRearLeft;
            //car.BrakeTemperatureRR = data.TemperatureBrakeRearRight;

            car.Speed = data.m_speed;
            //car.CarAccelerationLateral = data.GForceLateral;
            //car.CarAccelerationLongitudinal = data.GForceLongitudinal;

            //car.Throttle = data.PositionThrottle;
            //car.Brake = data.PositionBrake;
            //car.Clutch = data.PositionClutch;

            car.FuelCapacity = data.m_fuel_capacity;
            car.FuelLevel = data.m_fuel_in_tank;
            car.CalculateFuelPercentage();
        }

        //protected void writeDriverValues(Driver driver, CodemastersData.DirtRallyPacket data)
        //{
        //    driver.LapTimeCurrent = data.TimeCurrentLap;
        //}

        //protected void writeSessionValues(Session session, CodemastersData.DirtRallyPacket data)
        //{
        //}

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

        internal override void WriteValuesIntoDatapool(Games.Codemasters.ExtraData3 dataStructure, TelemetryDatapool datapool)
        {
            writeCarValues(datapool.car, dataStructure);
        }
    }
}
