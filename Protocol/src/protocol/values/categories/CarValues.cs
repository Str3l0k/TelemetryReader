using Telemetry.Protocol;

namespace Telemetry.Protocol.Values
{
    public static partial class TelemetryValues
    {
        public static partial class Car
        {
            public static class PowerTrain
            {
                #region Transmission
                public readonly static TelemetryValue<int> Gear = new TelemetryValue<int>(512);
                public readonly static TelemetryValue<int> GearMax = new TelemetryValue<int>(548);
                #endregion

                #region RPM
                public readonly static TelemetryValue<float> RPM = new TelemetryValue<float>(513);
                public readonly static TelemetryValue<float> RPMMax = new TelemetryValue<float>(514);
                public readonly static TelemetryValue<float> RPMRedline = new TelemetryValue<float>(515);
                public readonly static TelemetryValue<float> RPMPercentage = new TelemetryValue<float>(516);
                #endregion

                #region Engine
                public readonly static TelemetryValue<float> EngineCondition = new TelemetryValue<float>(527);
                public readonly static TelemetryValue<float> OilPressure = new TelemetryValue<float>(549);
                public readonly static TelemetryValue<float> OilTemperature = new TelemetryValue<float>(550);
                public readonly static TelemetryValue<float> WaterPressure = new TelemetryValue<float>(551);
                public readonly static TelemetryValue<float> WaterTemperature = new TelemetryValue<float>(552);

                public readonly static TelemetryValue<float> EnginePower = new TelemetryValue<float>(553);
                public readonly static TelemetryValue<float> EnginePowerMax = new TelemetryValue<float>(554);
                public readonly static TelemetryValue<float> EngineTorque = new TelemetryValue<float>(555);
                public readonly static TelemetryValue<float> EngineTorqueMax = new TelemetryValue<float>(556);
                #endregion
            }
        }

        public static partial class Car
        {
            public static class Body
            {
                #region Aero
                public readonly static TelemetryValue<float> AeroConditionAll = new TelemetryValue<float>(517);
                public readonly static TelemetryValue<float> AeroConditionFront = new TelemetryValue<float>(518);
                public readonly static TelemetryValue<float> AeroConditionRear = new TelemetryValue<float>(519);
                public readonly static TelemetryValue<float> AeroConditionLeft = new TelemetryValue<float>(520);
                public readonly static TelemetryValue<float> AeroConditionRight = new TelemetryValue<float>(521);
                #endregion
            }
        }

        public static partial class Car
        {
            public static class Control
            {
                public readonly static TelemetryValue<float> Throttle = new TelemetryValue<float>(522);
                public readonly static TelemetryValue<float> Brake = new TelemetryValue<float>(523);
                public readonly static TelemetryValue<float> Clutch = new TelemetryValue<float>(524);
                public readonly static TelemetryValue<float> Steering = new TelemetryValue<float>(525);
                public readonly static TelemetryValue<float> SteeringAngle = new TelemetryValue<float>(526);
            }
        }

        public static partial class Car
        {
            public static class Chassis
            {
                #region Brakes
                public readonly static TelemetryValue<float> BrakeConditionFL = new TelemetryValue<float>(528);
                public readonly static TelemetryValue<float> BrakeConditionFR = new TelemetryValue<float>(529);
                public readonly static TelemetryValue<float> BrakeConditionRL = new TelemetryValue<float>(530);
                public readonly static TelemetryValue<float> BrakeConditionRR = new TelemetryValue<float>(531);

                public readonly static TelemetryValue<float> BrakeTemperatureFL = new TelemetryValue<float>(532);
                public readonly static TelemetryValue<float> BrakeTemperatureFR = new TelemetryValue<float>(533);
                public readonly static TelemetryValue<float> BrakeTemperatureRL = new TelemetryValue<float>(534);
                public readonly static TelemetryValue<float> BrakeTemperatureRR = new TelemetryValue<float>(535);
                #endregion

                #region Tires
                public readonly static TelemetryValue<float> TireTemperatureFL = new TelemetryValue<float>(536);
                public readonly static TelemetryValue<float> TireTemperatureFR = new TelemetryValue<float>(537);
                public readonly static TelemetryValue<float> TireTemperatureRL = new TelemetryValue<float>(538);
                public readonly static TelemetryValue<float> TireTemperatureRR = new TelemetryValue<float>(539);

                public readonly static TelemetryValue<float> TireConditionFL = new TelemetryValue<float>(540);
                public readonly static TelemetryValue<float> TireConditionFR = new TelemetryValue<float>(541);
                public readonly static TelemetryValue<float> TireConditionRL = new TelemetryValue<float>(542);
                public readonly static TelemetryValue<float> TireConditionRR = new TelemetryValue<float>(543);

                public readonly static TelemetryValue<float> TirePressureFL = new TelemetryValue<float>(544);
                public readonly static TelemetryValue<float> TirePressureFR = new TelemetryValue<float>(545);
                public readonly static TelemetryValue<float> TirePressureRL = new TelemetryValue<float>(546);
                public readonly static TelemetryValue<float> TirePressureRR = new TelemetryValue<float>(547);

                public readonly static TelemetryValue<float> TireAngularSpeedFL = new TelemetryValue<float>(573);
                public readonly static TelemetryValue<float> TireAngularSpeedFR = new TelemetryValue<float>(574);
                public readonly static TelemetryValue<float> TireAngularSpeedRL = new TelemetryValue<float>(575);
                public readonly static TelemetryValue<float> TireAngularSpeedRR = new TelemetryValue<float>(576);

                public readonly static TelemetryValue<float> TireRadiusFL = new TelemetryValue<float>(577);
                public readonly static TelemetryValue<float> TireRadiusFR = new TelemetryValue<float>(578);
                public readonly static TelemetryValue<float> TireRadiusRL = new TelemetryValue<float>(579);
                public readonly static TelemetryValue<float> TireRadiusRR = new TelemetryValue<float>(580);
                #endregion

                #region Suspension
                public readonly static TelemetryValue<float> SuspensionRideHeightFL = new TelemetryValue<float>(557);
                public readonly static TelemetryValue<float> SuspensionRideHeightFR = new TelemetryValue<float>(558);
                public readonly static TelemetryValue<float> SuspensionRideHeightRL = new TelemetryValue<float>(559);
                public readonly static TelemetryValue<float> SuspensionRideHeightRR = new TelemetryValue<float>(560);

                public readonly static TelemetryValue<float> SuspensionRideHeightMaxFL = new TelemetryValue<float>(561);
                public readonly static TelemetryValue<float> SuspensionRideHeightMaxFR = new TelemetryValue<float>(562);
                public readonly static TelemetryValue<float> SuspensionRideHeightMaxRL = new TelemetryValue<float>(563);
                public readonly static TelemetryValue<float> SuspensionRideHeightMaxRR = new TelemetryValue<float>(564);

                public readonly static TelemetryValue<float> SuspensionTravelFL = new TelemetryValue<float>(565);
                public readonly static TelemetryValue<float> SuspensionTravelFR = new TelemetryValue<float>(566);
                public readonly static TelemetryValue<float> SuspensionTravelRL = new TelemetryValue<float>(567);
                public readonly static TelemetryValue<float> SuspensionTravelRR = new TelemetryValue<float>(568);

                public readonly static TelemetryValue<float> SuspensionCamberFL = new TelemetryValue<float>(569);
                public readonly static TelemetryValue<float> SuspensionCamberFR = new TelemetryValue<float>(570);
                public readonly static TelemetryValue<float> SuspensionCamberRL = new TelemetryValue<float>(571);
                public readonly static TelemetryValue<float> SuspensionCamberRR = new TelemetryValue<float>(572);
                #endregion
            }
        }

        public static partial class Car
        {
            public static class Fuel
            {
                public readonly static TelemetryValue<float> FuelLevel = new TelemetryValue<float>(581);
                public readonly static TelemetryValue<float> FuelPercentage = new TelemetryValue<float>(582);
                public readonly static TelemetryValue<float> FuelCapacity = new TelemetryValue<float>(583);
                public readonly static TelemetryValue<float> FuelPressure = new TelemetryValue<float>(584);

                public readonly static TelemetryValue<float> FuelUsagePerLap = new TelemetryValue<float>(585);
                public readonly static TelemetryValue<float> FuelUsagePerHour = new TelemetryValue<float>(586);
            }
        }

        public static partial class Car
        {
            public static class Physics
            {
                public readonly static TelemetryValue<float> AccelerationLateral = new TelemetryValue<float>(587);
                public readonly static TelemetryValue<float> AccelerationLongitudinal = new TelemetryValue<float>(588);
                public readonly static TelemetryValue<float> AccelerationVertical = new TelemetryValue<float>(589);

                public readonly static TelemetryValue<float> CoordinateX = new TelemetryValue<float>(590);
                public readonly static TelemetryValue<float> CoordinateY = new TelemetryValue<float>(591);
                public readonly static TelemetryValue<float> CoordinateZ = new TelemetryValue<float>(592);

                public readonly static TelemetryValue<float> Pitch = new TelemetryValue<float>(593);
                public readonly static TelemetryValue<float> Roll = new TelemetryValue<float>(594);
                public readonly static TelemetryValue<float> Yaw = new TelemetryValue<float>(595);

                public readonly static TelemetryValue<float> Speed = new TelemetryValue<float>(596);

                public readonly static TelemetryValue<float> PitchRate = new TelemetryValue<float>(597);
                public readonly static TelemetryValue<float> RollRate = new TelemetryValue<float>(598);
                public readonly static TelemetryValue<float> YawRate = new TelemetryValue<float>(599);

                public readonly static TelemetryValue<float> VelocityX = new TelemetryValue<float>(600);
                public readonly static TelemetryValue<float> VelocityY = new TelemetryValue<float>(601);
                public readonly static TelemetryValue<float> VelocityZ = new TelemetryValue<float>(602);

                public readonly static TelemetryValue<float> AngularVelocityX = new TelemetryValue<float>(603);
                public readonly static TelemetryValue<float> AngularVelocityY = new TelemetryValue<float>(604);
                public readonly static TelemetryValue<float> AngularVelocityZ = new TelemetryValue<float>(605);
            }
        }
    }
}
