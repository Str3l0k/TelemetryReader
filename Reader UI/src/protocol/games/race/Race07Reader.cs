using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TelemetryReader.src.protocol.datapool.categories;
using TelemetryReaderWpf.src.reader.impl;

namespace TelemetryReader.src.protocol.games.race
{
    class Race07Reader : SharedMemoryReader<Race07Data.SharedMemory>
    {
        /* constructor */
        public Race07Reader() : base("$Race$", Marshal.SizeOf(typeof(Race07Data.SharedMemory)))
        {
        }

        protected override Race07Data.SharedMemory initDataStruct()
        {
            return new Race07Data.SharedMemory();
        }

        protected override void writeCarValues(Car car, Race07Data.SharedMemory data)
        {
            #region drivesystem
            car.OilTemperature = data.engineOilTemp;
            car.OilPressure = data.engineOilPressure;
            car.WaterTemperature = data.engineWaterTemp;

            car.Gear = data.gear;
            car.RPM = R3EReader.rpsToRPM(data.rps);
            car.RPMMax = R3EReader.rpsToRPM(data.maxEngineRPS);
            #endregion

            #region fuelsystem
            car.FuelLevel = data.fuel;
            car.FuelCapacity = data.fuelCapacityLiters;
            car.FuelPressure = data.fuelPressure;
            #endregion

            #region chassis 
            car.TireTemperatureOuterFL = data.tirefrontleft.X;
            car.TireTemperatureMiddleFL = data.tirefrontleft.Y;
            car.TireTemperatureInnerFL = data.tirefrontleft.Z;

            car.TireTemperatureOuterFR = data.tirefrontright.Z;
            car.TireTemperatureMiddleFR = data.tirefrontright.Y;
            car.TireTemperatureInnerFR = data.tirefrontright.X;

            car.TireTemperatureOuterRL = data.tirerearleft.X;
            car.TireTemperatureMiddleRL = data.tirerearleft.Y;
            car.TireTemperatureInnerRL = data.tirerearleft.Z;

            car.TireTemperatureOuterRR = data.tirerearright.Z;
            car.TireTemperatureMiddleRR = data.tirerearright.Y;
            car.TireTemperatureInnerRR = data.tirerearright.X;
            #endregion

            // physics
            car.Speed = data.carSpeed;
            car.CarAccelerationLateral = data.acceleration.X;
            car.CarAccelerationLongitudinal = data.acceleration.Y;
        }

        protected override void writeDriverValues(Driver driver, Race07Data.SharedMemory data)
        {
            driver.LapCurrent = data.completedLaps + 1;
            driver.PositonCurrent = data.position;

            driver.LapTimeCurrent = data.lapTimeCurrent;
            driver.LapTimeLast = data.lapTimePrevious;
            driver.LapTimeBestSession = data.lapTimeBest;
        }

        protected override void writeSessionValues(Session session, Race07Data.SharedMemory data)
        {
            session.LapsTotal = (int)data.numberOfLaps;
            session.DriversTotal = data.numCars;
        }
    }
}
