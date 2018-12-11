//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using TelemetryReader.src.protocol.datapool.categories;
//using TelemetryReader.src.protocol.games.pcars;
//using TelemetryReaderWpf.src.reader.impl;
//using static TelemetryReader.src.protocol.games.pcars.ProjectCars2Data;

//namespace TelemetryReader.src.protocol.games
//{
//    class ProjectCars2Reader : SharedMemoryReader<ProjectCars2Data.SharedMemory>
//    {
//        /* constructor */
//        public ProjectCars2Reader() : base("$pcars2$", Marshal.SizeOf(typeof(ProjectCars2Data.SharedMemory)))
//        {
//        }

//        protected override ProjectCars2Data.SharedMemory initDataStruct()
//        {
//            return new ProjectCars2Data.SharedMemory();
//        }

//        protected override void writeCarValues(Car car, ProjectCars2Data.SharedMemory data)
//        {
//            // Body
//            car.AeroDamage = data.AeroDamage;

//            #region control unit
//            uint carBitfield = data.CarFlags;
//            bool absActive = data.AntiLockActive;
//            bool absEnabled = (carBitfield & CAR_ABS) != 0;
//            bool headlight = (carBitfield & CAR_HEADLIGHT) != 0;
//            bool pitlimiter = (carBitfield & CAR_SPEED_LIMITER) != 0;
//            bool tcactive = (carBitfield & CAR_TRACTION_CONTROL) != 0;

//            car.SystemsBitfield(absActive, absEnabled, false, false, data.BoostActive, headlight, pitlimiter, false, false, tcactive);
//            #endregion

//            #region controls/input
//            car.Throttle = data.Throttle;
//            car.Brake = data.Brake;
//            car.Clutch = data.Clutch;
//            car.SteeringPercent = data.Steering;
//            #endregion

//            #region chassis
//            car.TireTemperatureFL = data.TireTemp.FrontLeft;
//            car.TireTemperatureFR = data.TireTemp.FrontRight;
//            car.TireTemperatureRL = data.TireTemp.RearLeft;
//            car.TireTemperatureRR = data.TireTemp.RearRight;

//            car.TireConditionFL = 1f - data.TireWear.FrontLeft;
//            car.TireConditionFR = 1f - data.TireWear.FrontRight;
//            car.TireConditionRL = 1f - data.TireWear.RearLeft;
//            car.TireConditionRR = 1f - data.TireWear.RearRight;

//            car.TireRPSFL = data.TireRPS.FrontLeft;
//            car.TireRPSFR = data.TireRPS.FrontRight;
//            car.TireRPSRL = data.TireRPS.RearLeft;
//            car.TireRPSRR = data.TireRPS.RearRight;

//            car.BrakeTemperatureFL = data.BrakeTempCelsius.FrontLeft;
//            car.BrakeTemperatureFR = data.BrakeTempCelsius.FrontRight;
//            car.BrakeTemperatureRL = data.BrakeTempCelsius.RearLeft;
//            car.BrakeTemperatureRR = data.BrakeTempCelsius.RearRight;

//            car.SuspensionConditionFL = 1f - data.SuspensionDamage.FrontLeft;
//            car.SuspensionConditionFR = 1f - data.SuspensionDamage.FrontRight;
//            car.SuspensionConditionRL = 1f - data.SuspensionDamage.RearLeft;
//            car.SuspensionConditionRR = 1f - data.SuspensionDamage.RearRight;
//            #endregion

//            #region drivesystem
//            car.OilTemperature = data.OilTempCelsius;
//            car.OilPressure = data.OilPressureKPa;
//            car.WaterTemperature = data.WaterTempCelsius;
//            car.WaterPressure = data.WaterPressureKPa;
//            car.EngineCondition = 1f - data.EngineDamage;
//            car.ERSChargeLevel = data.BoostAmount / 100.0F;

//            bool engineActive = (carBitfield & CAR_ENGINE_ACTIVE) != 0;
//            bool engineWarning = (carBitfield & CAR_ENGINE_WARNING) != 0;

//            car.EngineBitfield(!engineActive, engineWarning, false, false, false);

//            car.Gear = data.Gear;
//            car.GearMax = data.NumGears;
//            car.RPM = data.Rpm;
//            car.RPMMax = data.MaxRPM;
//            #endregion

//            #region fuelsystem
//            car.FuelPercentage = data.FuelLevel;
//            car.FuelCapacity = data.FuelCapacity;
//            car.FuelPressure = data.FuelPressureKPa;
//            #endregion

//            #region physics
//            car.Speed = data.Speed;
//            car.CarAccelerationLateral = data.LocalAcceleration.X;
//            car.CarAccelerationLongitudinal = -data.LocalAcceleration.Z; // TODO check correct axis
//            #endregion
//        }

//        protected override void writeDriverValues(Driver driver, ProjectCars2Data.SharedMemory data)
//        {
//            int driverIndex = data.ViewedParticipantIndex;

//            if (driverIndex >= 0 && driverIndex < 64)
//            {
//                ParticipantInfo driverInfo = data.Participants[driverIndex];
//                driver.PositonCurrent = (int)driverInfo.mRacePosition;
//                driver.LapCurrent = (int)driverInfo.LapsCompleted + 1;
//            }

//            driver.LapTimeCurrent = data.CurrentTime;
//            driver.LapTimeLast = data.LastLapTime;
//            driver.LapTimeBestSession = data.BestLapTime;
//            driver.DeltaTimeToOpponentAhead = data.SplitTimeAhead;
//            driver.DeltaTimeToOpponentBehind = data.SplitTimeBehind;

//            #region sector timing
//            driver.Sector1TimeCurrent = data.CurrentSector1Time;
//            driver.Sector2TimeCurrent = data.CurrentSector2Time;
//            driver.Sector3TimeCurrent = data.CurrentSector3Time;

//            driver.Sector1TimeBestSession = data.FastestSector1Time;
//            driver.Sector2TimeBestSession = data.FastestSector2Time;
//            driver.Sector3TimeBestSession = data.FastestSector3Time;
//            #endregion
//        }

//        protected override void writeSessionValues(Session session, ProjectCars2Data.SharedMemory data)
//        {
//            session.GameState = (int) data.GameState;

//            session.LapsTotal = (int) data.LapsInEvent;
//            session.DriversTotal = data.NumParticipants;

//            session.TrackTemperatureAround = data.TrackTemperature;
//            session.AmbientTemperature = data.AmbientTemperature;
//        }
//    }
//}
