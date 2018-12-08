using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelemetryReader.src.protocol.datapool.categories
{
    public class Car : IDataWriter
    {
        #region systems bitmasks
        private static readonly int ABS_ACTIVE_BIT = 1 << 0;
        private static readonly int ABS_ENABLED_BIT = 1 << 1;
        private static readonly int DRS_AVAILABLE_BIT = 1 << 2;
        private static readonly int DRS_ACTIVE_BIT = 1 << 3;
        private static readonly int ERS_AVAILABLE_BIT = 1 << 4;
        private static readonly int HEADLIGHT_BIT = 1 << 5;
        private static readonly int PIT_LIMITER_BIT = 1 << 6;
        private static readonly int REV_LIMITER_BIT = 1 << 7;
        private static readonly int TC_ENABLED_BIT = 1 << 8;
        private static readonly int TC_ACTIVE_BIT = 1 << 9;
        #endregion

        #region engine bitmasks
        private static readonly int ENGINE_OFF_BIT = 1 << 0;
        private static readonly int ENGINE_WARNING_BIT = 1 << 1;
        private static readonly int ENGINE_FUEL_PRESSURE_WARNING_BIT = 1 << 2;
        private static readonly int ENGINE_OIL_PRESSURE_WARNING_BIT = 1 << 3;
        private static readonly int ENGINE_WATER_TEMPERATURE_WARNING_BIT = 1 << 4;
        #endregion

        #region car position/pit masks
        private static readonly int APPROACHING_PIT_BIT = 1 << 0;
        private static readonly int IN_PIT_BOX_BIT = 1 << 1;
        private static readonly int IN_PIT_LANE_BIT = 1 << 2;
        private static readonly int ON_TRACK_BIT = 1 << 3;
        private static readonly int LEAVING_PIT_BIT = 1 << 4;
        private static readonly int OFF_TRACK_BIT = 1 << 5;
        #endregion

        /* decorated writer */
        private IDataWriter dataWriter;

        /* constructor */
        public Car(IDataWriter dataWriter)
        {
            this.dataWriter = dataWriter;
        }

        #region decorator interface
        public void writeFloatValue(ushort ID, float value)
        {
            dataWriter.writeFloatValue(ID, value);
        }

        public void writeIntegerValue(ushort ID, int value)
        {
            dataWriter.writeIntegerValue(ID, value);
        }

        public void writeStringValue(ushort ID, string value)
        {
            dataWriter.writeStringValue(ID, value);
        }

        public void writeBitfieldValue(ushort ID, int bitfield)
        {
            dataWriter.writeBitfieldValue(ID, bitfield);
        }
        #endregion
        
        #region bitfield helper
        public void SystemsBitfield(
            bool ABSActive,
            bool ABSEnabled,
            bool DRSAvailable, // TODO
            bool DRSActive, // TODO
            bool ERSAvailable,
            bool Headlight,
            bool pitLimiter,
            bool revLimiter,// TODO
            bool TractionControlEnabled,
            bool TractionControlActive)
        {
            int bitfield = 0;

            if(ABSActive)
            {
                bitfield |= ABS_ACTIVE_BIT;
            }

            if (ABSEnabled)
            {
                bitfield |= ABS_ENABLED_BIT;
            }

            if(ERSAvailable)
            {
                bitfield |= ERS_AVAILABLE_BIT;
            }

            if(Headlight)
            {
                bitfield |= HEADLIGHT_BIT;
            }

            if (pitLimiter)
            {
                bitfield |= PIT_LIMITER_BIT;
            }

            if(TractionControlEnabled)
            {
                bitfield |= TC_ENABLED_BIT;
            }

            if(TractionControlActive)
            {
                bitfield |= TC_ACTIVE_BIT;
            }

            systemsBitfield = bitfield;
        }
        
        public void EngineBitfield(
            bool engineOff,
            bool engineWarning,
            bool fuelPressureWarning,
            bool oilPressureWarning,
            bool waterTempWarning)
        {
            int bitfield = 0;

            if(engineOff)
            {
                bitfield |= ENGINE_OFF_BIT;
            }

            if(engineWarning)
            {
                bitfield |= ENGINE_WARNING_BIT;
            }

            if(fuelPressureWarning)
            {
                bitfield |= ENGINE_FUEL_PRESSURE_WARNING_BIT;
            }

            if(oilPressureWarning)
            {
                bitfield |= ENGINE_OIL_PRESSURE_WARNING_BIT;
            }

            if(waterTempWarning)
            {
                bitfield |= ENGINE_WATER_TEMPERATURE_WARNING_BIT;
            }

            engineBitfield = bitfield;
        }
        
        public void CarPositionBitfield(
            bool approachingPit,
            bool inPitBox,
            bool inPitLane,
            bool onTrack,
            bool leavingPit,
            bool offTrack)
        {
            int bitfield = 0;

            if (approachingPit)
            {
                bitfield |= APPROACHING_PIT_BIT;
            }

            if (inPitBox)
            {
                bitfield |= IN_PIT_BOX_BIT;
            }

            if (inPitLane)
            {
                bitfield |= IN_PIT_LANE_BIT;
            }

            if (onTrack)
            {
                bitfield |= ON_TRACK_BIT;
            }

            if (leavingPit)
            {
                bitfield |= LEAVING_PIT_BIT;
            }

            if (offTrack)
            {
                bitfield |= OFF_TRACK_BIT;
            }

            carPositionBitfield = bitfield;
        }
        #endregion

        #region actual value properties

        #region body
        public float AeroDamage { set { writeFloatValue(2048, value); } }
        #endregion

        #region carcontrolunit
        public float ABSLevel { set { writeFloatValue(2062, value); } }
        public float TCLevel1 { set { writeFloatValue(2112, value); } }
        public float TCLevel2 { set { writeFloatValue(2113, value); } }
        private int systemsBitfield { set { writeBitfieldValue(2063, value); } }
        #endregion

        #region controls/input
        public float Throttle { set { writeFloatValue(2080, value); } }
        public float Brake { set { writeFloatValue(2074, value); } }
        public float Clutch { set { writeFloatValue(2076, value); } }
        public float SteeringAngle { set { writeFloatValue(2079, value); } }
        public float SteeringPercent { set { writeFloatValue(2078, value); } }
        #endregion

        #region chassis
        #region tires
        public float TireDirtLevelFL { set { writeFloatValue(2274, value); } }
        public float TireDirtLevelFR { set { writeFloatValue(2275, value); } }
        public float TireDirtLevelRL { set { writeFloatValue(2276, value); } }
        public float TireDirtLevelRR { set { writeFloatValue(2277, value); } }

        public float TireConditionFL { set { writeFloatValue(2178, value); } }
        public float TireConditionFR { set { writeFloatValue(2179, value); } }
        public float TireConditionRL { set { writeFloatValue(2180, value); } }
        public float TireConditionRR { set { writeFloatValue(2181, value); } }
        
        public float TireTemperatureFL { set { writeFloatValue(2182, value); } }
        public float TireTemperatureFR { set { writeFloatValue(2183, value); } }
        public float TireTemperatureRL { set { writeFloatValue(2184, value); } }
        public float TireTemperatureRR { set { writeFloatValue(2185, value); } }

        public float TireTemperatureOuterFL { set { writeFloatValue(2186, value); } }
        public float TireTemperatureMiddleFL { set { writeFloatValue(2187, value); } }
        public float TireTemperatureInnerFL { set { writeFloatValue(2188, value); } }

        public float TireTemperatureInnerFR { set { writeFloatValue(2191, value); } }
        public float TireTemperatureMiddleFR { set { writeFloatValue(2190, value); } }
        public float TireTemperatureOuterFR { set { writeFloatValue(2189, value); } }

        public float TireTemperatureOuterRL { set { writeFloatValue(2192, value); } }
        public float TireTemperatureMiddleRL { set { writeFloatValue(2193, value); } }
        public float TireTemperatureInnerRL { set { writeFloatValue(2194, value); } }

        public float TireTemperatureInnerRR { set { writeFloatValue(2197, value); } }
        public float TireTemperatureMiddleRR { set { writeFloatValue(2196, value); } }
        public float TireTemperatureOuterRR { set { writeFloatValue(2195, value); } }

        public float TireRPSFL { set { writeFloatValue(2254, value); } }
        public float TireRPSFR { set { writeFloatValue(2255, value); } }
        public float TireRPSRL { set { writeFloatValue(2256, value); } }
        public float TireRPSRR { set { writeFloatValue(2257, value); } }

        public float TirePressureFL { set { writeFloatValue(2222, value); } }
        public float TirePressureFR { set { writeFloatValue(2223, value); } }
        public float TirePressureRL { set { writeFloatValue(2224, value); } }
        public float TirePressureRR { set { writeFloatValue(2225, value); } }       
        #endregion

        #region brakes
        public float BrakeTemperatureFL { set { writeFloatValue(2126, value); } }
        public float BrakeTemperatureFR { set { writeFloatValue(2127, value); } }
        public float BrakeTemperatureRL { set { writeFloatValue(2128, value); } }
        public float BrakeTemperatureRR { set { writeFloatValue(2129, value); } }
        #endregion

        #region suspension
        public float SuspensionCamberFL { set { writeFloatValue(2130, value); } }
        public float SuspensionCamberFR { set { writeFloatValue(2131, value); } }
        public float SuspensionCamberRL { set { writeFloatValue(2132, value); } }
        public float SuspensionCamberRR { set { writeFloatValue(2133, value); } }

        public float SuspensionConditionFL { set { writeFloatValue(2134, value); } }
        public float SuspensionConditionFR { set { writeFloatValue(2135, value); } }
        public float SuspensionConditionRL { set { writeFloatValue(2136, value); } }
        public float SuspensionConditionRR { set { writeFloatValue(2137, value); } }
        #endregion
        #endregion

        #region drivesystem
        #region engine
        public float OilTemperature { set { writeFloatValue(2309, value); } }
        public float OilPressure { set { writeFloatValue(2308, value); } }
        public float WaterTemperature { set { writeFloatValue(2312, value); } }
        public float WaterPressure { set { writeFloatValue(2311, value); } }
        public float EngineVoltage { set { writeFloatValue(2306, value); } }
        public float EngineCondition { set { writeFloatValue(2290, value); } }
        private int engineBitfield { set { writeBitfieldValue(2092, value); } }
        #endregion

        #region ers
        public float ERSChargeLevel { set { writeFloatValue(2316, value); } }
        #endregion

        #region transmission 
        public int Gear { set { writeIntegerValue(2318, value); } }
        public int GearMax { set { writeIntegerValue(2319, value); } }
        public float RPM { set { writeFloatValue(2295, value); } }
        public float RPMMax { set { writeFloatValue(2296, value); } }
        #endregion
        #endregion

        #region fuelsystem
        public float FuelLevel { set { writeFloatValue(2323, value); } }
        public float FuelCapacity { set { writeFloatValue(2322, value); } }
        public float FuelPercentage { set { writeFloatValue(2324, value); } }
        public float FuelPressure { set { writeFloatValue(2321, value); } }
        #endregion 

        #region physics
        public float Speed { set { writeFloatValue(2335, value); } }
        public float CarAccelerationLateral { set { writeFloatValue(2329, value); } }
        public float CarAccelerationLongitudinal { set { writeFloatValue(2330, value); } }
        public float CarAccelerationVertical { set { writeFloatValue(2331, value); } }
        #endregion

        #endregion

        #region
        private int carPositionBitfield { set { writeBitfieldValue(2100, value); } }
        #endregion
    }
}
