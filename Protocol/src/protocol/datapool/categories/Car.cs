using Telemetry.Protocol.Datapool;
using Telemetry.Protocol.Values;

namespace Telemetry.Protocol
{
    public class Car : ValueAccessor
    {
        public Car(IValueReader valueReader, IValueWriter valueWriter) : base(valueReader, valueWriter)
        {
        }

        /* classes */
        #region powertrain
        public int Gear
        {
            get => ReadInt(TelemetryValues.Car.PowerTrain.Gear.ID);
            set => WriteInteger(TelemetryValues.Car.PowerTrain.Gear.ID, value);
        }

        public float RPM
        {
            get => ReadFloat(TelemetryValues.Car.PowerTrain.RPM.ID);
            set
            {
                WriteFloat(TelemetryValues.Car.PowerTrain.RPM.ID, value);
                var rpmMax = ReadFloat(TelemetryValues.Car.PowerTrain.RPMMax.ID);
                RPMPercentage = value / rpmMax;
            }
        }

        public float RPMMax
        {
            get => ReadFloat(TelemetryValues.Car.PowerTrain.RPMMax.ID);
            set
            {
                WriteFloat(TelemetryValues.Car.PowerTrain.RPMMax.ID, value);
                var rpm = ReadFloat(TelemetryValues.Car.PowerTrain.RPM.ID);
                RPMPercentage = rpm / value;
            }
        }

        public float RPMPercentage
        {
            get => ReadFloat(TelemetryValues.Car.PowerTrain.RPMPercentage.ID);
            set => WriteFloat(TelemetryValues.Car.PowerTrain.RPMPercentage.ID, value);
        }
        #endregion

        #region Physics
        public float Speed
        {
            get => ReadFloat(TelemetryValues.Car.Physics.Speed.ID);
            set => WriteFloat(TelemetryValues.Car.Physics.Speed.ID, value);
        }
        #endregion
    }
}
