using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using R3EData.Data;
using TelemetryReader.src.protocol.datapool.categories;
using TelemetryReaderWpf.src.reader.impl;


namespace TelemetryReader.src.protocol.games
{
    class R3EReader : SharedMemoryReader<R3EData.Data.R3E>
    {
        public static readonly float RPS_TO_RPM = (60 / (2 * (float)Math.PI));

        /* constructor */
        public R3EReader() : base("$R3E", Marshal.SizeOf(typeof(R3EData.Data.R3E)))
        {

        }

        protected override R3E initDataStruct()
        {
            return new R3EData.Data.R3E();
        }

        public static float rpsToRPM(float rps)
        {
            return rps * RPS_TO_RPM;
        }

        protected override void writeCarValues(Car car, R3EData.Data.R3E data)
        {
            #region body
            car.AeroDamage = data.CarDamage.Aerodynamics;
            #endregion

            #region controls
            car.Throttle = data.ThrottlePedal;
            car.Brake = data.BrakePedal;
            car.Clutch = data.ClutchPedal;           
            #endregion

            #region control unit
            car.SystemsBitfield(false, false, false, false, false, false, data.PitLimiter == 1, false, false, false);
            #endregion

            #region engine
            car.EngineCondition = 1f - data.CarDamage.Engine;
            car.OilPressure = data.EngineOilPressure;
            car.OilTemperature = data.EngineOilTemp;
            car.WaterTemperature = data.EngineWaterTemp;
            #endregion

            #region transmission
            car.Gear = data.Gear;
            car.GearMax = data.NumGears;
            car.RPM = rpsToRPM(data.EngineRps);
            car.RPMMax = rpsToRPM(data.MaxEngineRps);
            #endregion

            #region fuelsystem
            car.FuelPressure = data.FuelPressure;
            car.FuelCapacity = data.FuelCapacity;
            car.FuelLevel = data.FuelLeft;
            #endregion

            #region chassis
            car.TireTemperatureOuterFL = data.TireTemp.FrontLeft_Left;
            car.TireTemperatureMiddleFL = data.TireTemp.FrontLeft_Center;
            car.TireTemperatureInnerFL = data.TireTemp.FrontLeft_Right;

            car.TireTemperatureInnerFR = data.TireTemp.FrontRight_Left;
            car.TireTemperatureMiddleFR = data.TireTemp.FrontRight_Center;
            car.TireTemperatureOuterFR = data.TireTemp.FrontRight_Right;

            car.TireTemperatureOuterRL = data.TireTemp.RearLeft_Left;
            car.TireTemperatureMiddleRL = data.TireTemp.RearLeft_Center;
            car.TireTemperatureInnerRL = data.TireTemp.RearLeft_Right;

            car.TireTemperatureInnerRR = data.TireTemp.RearRight_Left;
            car.TireTemperatureMiddleRR = data.TireTemp.RearRight_Center;
            car.TireTemperatureOuterRR = data.TireTemp.RearRight_Right;

            car.TireDirtLevelFL = data.TireDirt.FrontLeft;
            car.TireDirtLevelFR = data.TireDirt.FrontRight;
            car.TireDirtLevelRL = data.TireDirt.RearLeft;
            car.TireDirtLevelRR = data.TireDirt.RearRight;

            car.TireConditionFL = data.TireWear.FrontLeft;
            car.TireConditionFR = data.TireWear.FrontRight;
            car.TireConditionRL = data.TireWear.RearLeft; 
            car.TireConditionRR = data.TireWear.RearRight; 

            car.TirePressureFL = data.TirePressure.FrontLeft;
            car.TirePressureFR = data.TirePressure.FrontRight;
            car.TirePressureRL = data.TirePressure.RearLeft;
            car.TirePressureRR = data.TirePressure.RearRight;

            car.TireRPSFL = data.TireRps.FrontLeft;
            car.TireRPSFR = data.TireRps.FrontRight;
            car.TireRPSRL = data.TireRps.RearLeft;
            car.TireRPSRR = data.TireRps.RearRight;

            car.BrakeTemperatureFL = data.BrakeTemp.FrontLeft;
            car.BrakeTemperatureFR = data.BrakeTemp.FrontRight;
            car.BrakeTemperatureRL = data.BrakeTemp.RearLeft;
            car.BrakeTemperatureRR = data.BrakeTemp.RearRight;
            #endregion

            #region physics
            car.Speed = data.CarSpeed;
            car.CarAccelerationLateral = data.LocalAcceleration.X; // TODO check correct unit and axis
            car.CarAccelerationLongitudinal = -data.LocalAcceleration.Z;
            #endregion
        }

        protected override void writeDriverValues(Driver driver, R3EData.Data.R3E data)
        {
            // session
            driver.LapCurrent = data.CompletedLaps + 1;
            driver.PositonCurrent = data.Position;

            // timing
            driver.LapTimeCurrent = data.LapTimeCurrentSelf;
            driver.LapTimeLast = data.LapTimePreviousSelf;
            driver.LapTimeBestSession = data.LapTimeBestSelf;

            // opponent deltas
            driver.DeltaTimeToOpponentAhead = data.TimeDeltaFront;
            driver.DeltaTimeToOpponentBehind = data.TimeDeltaBehind;
        }

        protected override void writeSessionValues(Session session, R3EData.Data.R3E data)
        {
            //session.se
            session.SessionState = data.SessionPhase;

            session.LapsTotal = data.NumberOfLaps;
            session.DriversTotal = data.NumCars;
        }
    }
}
