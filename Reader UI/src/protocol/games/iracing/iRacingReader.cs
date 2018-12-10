//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using R3EData.Data;
//using iRSDKSharp;
//using TelemetryReaderWpf.src.reader;
//using System.Threading;
//using TelemetryReader.src.protocol.datapool.categories;
//using iRacingSdkWrapper;
//using System.Globalization;

//namespace TelemetryReader.src.protocol.games
//{
//    class iRacingReader : GameReader<iRacingTelemetry>
//    {
//        private iRacingSDK sdk;

//        /* constructor */
//        public iRacingReader() : base()
//        {
//        }

//        #region reader interface 
//        /* Reader interface */
//        public override bool dataAvailable()
//        {
//            if (!sdk.IsInitialized || !sdk.IsConnected())
//            {
//                //Thread.Sleep(10000); // hacky hack hack

//                if (!sdk.Startup())
//                {
//                    sdk = new iRacingSDK();
//                }
//            }

//            if (sdk.VarHeaderSize <= 0)
//            {
//                sdk.Startup();
//            }

//            return sdk.IsInitialized && sdk.IsConnected();
//        }

//        public override SendData Read()
//        {
//            updateSessionData(data, car, driver, session);
//            writeValues(data);
//            return protocolPacketData.getData(valueDictionary.Values);
//        }

//        public override void shutdown()
//        {
//            sdk.Shutdown();
//        }
//        #endregion

//        #region data converter
//        protected override iRacingTelemetry initDataStruct()
//        {
//            sdk = new iRacingSDK();
//            return new iRacingTelemetry(sdk);
//        }

//        protected override void writeCarValues(Car car, iRacingTelemetry data)
//        {
//            #region controls/input
//            car.Throttle = data.Throttle;
//            car.Brake = data.Brake;
//            car.Clutch = data.Clutch;
//            car.SteeringAngle = data.SteeringWheelAngle;
//            #endregion

//            #region drivesystem
//            // engine
//            car.OilTemperature = data.OilTemp;
//            car.OilPressure = data.OilPress * 100f;
//            car.WaterTemperature = data.WaterTemp;
//            car.EngineVoltage = data.EngineVoltage;

//            int engineWarningBitfield = data.EngineWarnings;
//            bool engineOff = (engineWarningBitfield & iRacingTelemetry.ENGINE_OFF_BIT) != 0;
//            bool fuelPressureWarning = (engineWarningBitfield & iRacingTelemetry.FUEL_PRESSURE_WARNING_BIT) != 0;
//            bool oilPressureWarning = (engineWarningBitfield & iRacingTelemetry.OIL_PRESSURE_WARNING_BIT) != 0;
//            bool waterTempWarning = (engineWarningBitfield & iRacingTelemetry.WATER_TEMP_WARNING_BIT) != 0;

//            car.EngineBitfield(engineOff, false, fuelPressureWarning, oilPressureWarning, waterTempWarning);

//            // transmission
//            car.Gear = data.Gear;
//            car.RPM = data.RPM;
//            #endregion

//            #region fuelsystem
//            car.FuelLevel = data.FuelLevel;
//            car.FuelPercentage = data.FuelLevelPct;
//            car.FuelPressure = data.FuelPressure * 100f;
//            #endregion

//            #region physics
//            car.Speed = data.Speed;
//            car.CarAccelerationLateral = data.LatAccel;
//            car.CarAccelerationLongitudinal = data.LongAccel;
//            #endregion

//            car.CarPositionBitfield(false, data.IsInGarage, false, data.IsOnTrack, false, false);
//        }

//        protected override void writeDriverValues(Driver driver, iRacingTelemetry data)
//        {
//            driver.LapTimeCurrent = data.LapTimeCurrent;
//            driver.LapTimeLast = data.LapTimeLast;
//            driver.LapTimeBestSession = data.LapTimeBestSession;
//            driver.writeFloatValue(6219, data.LapTimeDeltaLastLap);

//            driver.LapCurrent = data.Lap;
//            driver.PositonCurrent = data.PlayerPosition;
//        }

//        protected override void writeSessionValues(Session session, iRacingTelemetry dataStruct)
//        {
//            session.SessionState = dataStruct.SessionState;
//            session.SessionID = dataStruct.SessionUniqueID;

//            Console.WriteLine(dataStruct.SessionUniqueID);
//        }

//        private int newUpdate = -1;
//        private int sessionID = -1;
//        private int sessionNumber = -1;

//        private void updateSessionData(iRacingTelemetry data, Car car, Driver driver, Session session)
//        {
//            session.LapsTotal = data.LapCompleted + data.LapsRemaining;

//            int newUpdate = sdk.Header.SessionInfoUpdate;
//            int sessionID = (int)sdk.GetData("SessionUniqueID");
//            int sessionNumber = (int)sdk.GetData("SessionNum");

//            if (this.newUpdate != newUpdate || this.sessionID != sessionID || this.sessionNumber != sessionNumber)
//            {
//                var time = (double)sdk.GetData("SessionTime");
//                SessionInfo sessionInfo = new SessionInfo(sdk.GetSessionInfo(), time);

//                float f = 0;
//                int i = 0;

//                string temp = sessionInfo.TryGetValue("DriverInfo:DriverCarRedLine:");
//                if (float.TryParse(temp, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out f))
//                {
//                    car.RPMMax = f;
//                }

//                temp = sessionInfo.TryGetValue("WeekendInfo:WeekendOptions:NumStarters");
//                if (int.TryParse(temp, NumberStyles.Integer, CultureInfo.GetCultureInfo("en-US"), out i))
//                {
//                    session.DriversTotal = i;
//                }

//                this.newUpdate = newUpdate;
//                this.sessionID = sessionID;
//                this.sessionNumber = sessionNumber;
//            }
//        }

//        #endregion
//    }
//}
