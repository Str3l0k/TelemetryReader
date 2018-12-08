//using iRacingSdkWrapper;
//using iRSDKSharp;
//using System;
//using System.Globalization;
//using System.Runtime.InteropServices;
//using System.Threading;
//using TelemetryReader.src.protocol;
//using TelemetryReaderWpf.src.context;

//namespace TelemetryReaderWpf.src.reader.impl
//{
//    public class iRacingReader : Reader
//    {
//        private iRacingSDK iRacingSDK;
//        private iRacingData iRacingData;

//        private int session = -1;
//        private int counter = 0;
        
//        public iRacingReader(int readerVersion)
//        {
//            iRacingSDK = new iRacingSDK();
//            iRacingData = new iRacingData();

//            iRacingData.mGameCode = GameContext.iRacingID;
//            iRacingData.mReaderVersion = readerVersion;
//            iRacingData.mSessionID = 0xFF;
//        }

//        public bool dataAvailable()
//        {
//            if (!iRacingSDK.IsInitialized || !iRacingSDK.IsConnected())
//            {
//                Thread.Sleep(10000); // hacky hack hack

//                if (!iRacingSDK.Startup())
//                {
//                    iRacingSDK = new iRacingSDK();
//                }
//            }

//            if (iRacingSDK.VarHeaderSize <= 0)
//            {
//                iRacingSDK.Startup();
//            }

//            return iRacingSDK.IsInitialized && iRacingSDK.IsConnected();
//        }

//        public SendData Read()
//        {
//            if (iRacingSDK != null)
//            {
//                extractData();
//                byte[] data = StructToBytes(iRacingData);
//                return new SendData(data);
//            }
//            else
//            {
//                return null;
//            }
//        }

//        /* conversion */
//        public static byte[] StructToBytes<TStruct>(TStruct str) where TStruct : struct
//        {
//            int structSize = Marshal.SizeOf(typeof(TStruct));
//            byte[] arr = new byte[structSize];
//            IntPtr ptr = Marshal.AllocHGlobal(structSize);

//            Marshal.StructureToPtr(str, ptr, false);
//            Marshal.Copy(ptr, arr, 0, structSize);
//            Marshal.FreeHGlobal(ptr);

//            return arr;
//        }

//        /* testing */
//        private int testForBoolData(object o)
//        {
//            if (o == null || o.GetType() != typeof(bool))
//            {
//                return 0;
//            }
//            else
//            {
//                if ((bool)o)
//                    return 1;
//                else
//                    return 0;
//            }
//        }

//        private int testDataForInt(object o)
//        {
//            if (o == null || o.GetType() != typeof(int))
//                return 0;
//            else
//                return (int)o;
//        }

//        private float testDataForFloat(object o)
//        {
//            if (o == null || o.GetType() != typeof(float))
//                return 0;
//            else
//                return (float)o;
//        }

//        /* extraction */
//        private void extractData()
//        {
//            // Car
//            iRacingData.mIsInPit = testForBoolData(iRacingSDK.GetData("OnPitRoad"));
//            // Engine
//            iRacingData.mOilTemp = testDataForFloat(iRacingSDK.GetData("OilTemp"));
//            iRacingData.mOilLevel = testDataForFloat(iRacingSDK.GetData("OilLevel"));
//            iRacingData.mOilPressure = testDataForFloat(iRacingSDK.GetData("OilPress"));
//            iRacingData.mWaterTemp = testDataForFloat(iRacingSDK.GetData("WaterTemp"));
//            iRacingData.mWaterLevel = testDataForFloat(iRacingSDK.GetData("WaterLevel"));
//            iRacingData.mVoltage = testDataForFloat(iRacingSDK.GetData("Voltage"));
//            iRacingData.mManifoldPressure = testDataForFloat(iRacingSDK.GetData("ManifoldPress"));
//            iRacingData.mEngineWarningBitField = testDataForInt(iRacingSDK.GetData("EngineWarnings"));
//            //Tranmission
//            iRacingData.mGear = testDataForInt(iRacingSDK.GetData("Gear"));
//            iRacingData.mCurrentRPM = testDataForFloat(iRacingSDK.GetData("RPM"));
//            //iRacingData.mMaxRPM = testDataForFloat(iRacingSDK.GetData("ShiftGrindRPM"));

//            if (counter > 1)
//                iRacingData.mSessionID = testDataForInt(iRacingSDK.GetData("SessionState"));
//            else
//                counter++;

//            int newUpdate = iRacingSDK.Header.SessionInfoUpdate;
//            if (newUpdate != session || iRacingData.mMaxRPM <= 0 || iRacingData.mBlinkRPM <= 0 || iRacingData.mFirstLEDRPM <= 0 || iRacingData.mShiftRPM <= 0)
//            {
//                session = newUpdate;

//                string temp = "";

//                var time = (double)iRacingSDK.GetData("SessionTime");
//                SessionInfo sessionInfo = new SessionInfo(iRacingSDK.GetSessionInfo(), time);

//                float f = 0;

//                temp = sessionInfo.TryGetValue("DriverInfo:DriverCarRedLine:");
//                if (float.TryParse(temp, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out f))
//                {
//                    iRacingData.mMaxRPM = f;
//                }

//                f = 0;
//                temp = sessionInfo.TryGetValue("DriverInfo:DriverCarSLShiftRPM:");
//                if (float.TryParse(temp, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out f))
//                {
//                    iRacingData.mShiftRPM = f;
//                }


//                f = 0;
//                temp = sessionInfo.TryGetValue("DriverInfo:DriverCarSLBlinkRPM:");
//                if (float.TryParse(temp, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out f))
//                {
//                    iRacingData.mBlinkRPM = f;
//                }

//                f = 0;
//                temp = sessionInfo.TryGetValue("DriverInfo:DriverCarSLFirstRPM:");
//                if (float.TryParse(temp, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out f))
//                {
//                    iRacingData.mFirstLEDRPM = f;
//                }
//            }

//            // Fuel
//            iRacingData.mFuelLevel = testDataForFloat(iRacingSDK.GetData("FuelLevel"));
//            iRacingData.mFuelPercent = testDataForFloat(iRacingSDK.GetData("FuelLevelPct"));
//            iRacingData.mFuelPressure = testDataForFloat(iRacingSDK.GetData("FuelPress"));

//            iRacingData.mLatitude = testDataForFloat(iRacingSDK.GetData("Lat"));
//            iRacingData.mLongtitude = testDataForFloat(iRacingSDK.GetData("Lon"));

//            iRacingData.mYaw = testDataForFloat(iRacingSDK.GetData("Yaw"));
//            iRacingData.mPitch = testDataForFloat(iRacingSDK.GetData("Pitch"));
//            iRacingData.mRoll = testDataForFloat(iRacingSDK.GetData("Roll"));

//            iRacingData.mFlagBitField = testDataForInt(iRacingSDK.GetData("SessionFlags"));

//            iRacingData.mVelocityX = testDataForFloat(iRacingSDK.GetData("VelocityX"));
//            iRacingData.mVelocityY = testDataForFloat(iRacingSDK.GetData("VelocityY"));
//            iRacingData.mVelocityZ = testDataForFloat(iRacingSDK.GetData("VelocityZ"));

//            // Physics
//            iRacingData.mThrottleInput = testDataForFloat(iRacingSDK.GetData("Throttle"));
//            iRacingData.mBrakeInput = testDataForFloat(iRacingSDK.GetData("Brake"));
//            iRacingData.mClutchInput = testDataForFloat(iRacingSDK.GetData("Clutch"));
//            iRacingData.mSteeringAngleInput = testDataForFloat(iRacingSDK.GetData("SteeringWheelAngle"));
//            iRacingData.mCurrentSpeed = testDataForFloat(iRacingSDK.GetData("Speed"));
//            iRacingData.mLatAcceleration = testDataForFloat(iRacingSDK.GetData("LatAccel"));
//            iRacingData.mLongAcceleration = testDataForFloat(iRacingSDK.GetData("LongAccel"));

//            // Timing
//            iRacingData.mCurrentLapTime = testDataForFloat(iRacingSDK.GetData("LapCurrentLapTime"));
//            iRacingData.mLastLapTime = testDataForFloat(iRacingSDK.GetData("LapLastLapTime"));
//            iRacingData.mBestLapTime = testDataForFloat(iRacingSDK.GetData("LapBestLapTime"));
//            iRacingData.mDeltaToBest = testDataForFloat(iRacingSDK.GetData("LapDeltaToBestLap"));
//            iRacingData.mDeltaToSessionBest = testDataForFloat(iRacingSDK.GetData("LapDeltaToSessionBestLap"));

//            // Session
//            iRacingData.mCurrentLap = testDataForInt(iRacingSDK.GetData("Lap"));
//            iRacingData.mCompletedRaceLaps = testDataForInt(iRacingSDK.GetData("RaceLaps"));
//            iRacingData.mLapsRemaining = testDataForInt(iRacingSDK.GetData("SessionLapsRemain"));
//            iRacingData.mDistanceTraveled = testDataForFloat(iRacingSDK.GetData("LapDist"));
//            iRacingData.mDistanceTraveledPercent = testDataForFloat(iRacingSDK.GetData("LapDistPct"));
//            //iRacingData.mSessionTimeRemaining = testDataForFloat(iRacingSDK.GetData("SessionTimeRemain"));

//            // weather TODO
//        }

//        public void shutdown()
//        {
//            if (iRacingSDK != null)
//            {
//                iRacingSDK.Shutdown();
//            }
//        }
//    }
//}
