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

        #region Fuel
        public float FuelLevel
        {
            get => ReadFloat(TelemetryValues.Car.Fuel.FuelLevel.ID);
            set => WriteFloat(TelemetryValues.Car.Fuel.FuelLevel.ID, value);
        }

        public float FuelPercentage
        {
            get => ReadFloat(TelemetryValues.Car.Fuel.FuelPercentage.ID);
            set => WriteFloat(TelemetryValues.Car.Fuel.FuelPercentage.ID, value);
        }

        public float FuelCapacity
        {
            get => ReadFloat(TelemetryValues.Car.Fuel.FuelCapacity.ID);
            set => WriteFloat(TelemetryValues.Car.Fuel.FuelCapacity.ID, value);
        }

        public void CalculateFuelPercentage()
        {
            FuelPercentage = FuelLevel / FuelCapacity;
        }

        public void CalculateFuelLevel()
        {
            FuelLevel = FuelPercentage * FuelCapacity;
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
