using AssettoCorsaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TelemetryReaderWpf.src.reader.impl;
using TelemetryReader.src.protocol.datapool.categories;

namespace TelemetryReader.src.protocol.games.assetto
{
    class AssettoCorsaPhysicsReader : SharedMemoryReader<AssettoCorsa.SPageFilePhysics>
    {
        /* constructor */
        public AssettoCorsaPhysicsReader() : base("acpmf_physics", Marshal.SizeOf(typeof(AssettoCorsa.SPageFilePhysics)))
        {
        }

        protected override AssettoCorsa.SPageFilePhysics initDataStruct()
        {
            return new AssettoCorsa.SPageFilePhysics();
        }

        private float psiToKpa(float psi)
        {
            return psi * 6.89475729f;
        }

        protected override void writeCarValues(Car car, AssettoCorsa.SPageFilePhysics data)
        {
            car.RPM = data.rpms;
            car.Gear = data.gear - 1;
            car.ABSLevel = data.abs;
            car.TCLevel1 = data.tc;
            car.SystemsBitfield(false, false, data.drsAvailable == 1, data.drsEnabled == 1, false, false, data.pitLimiterOn == 1, false, false, false);
            car.FuelLevel = data.fuel;

            car.TireTemperatureFL = data.tyreCoreTemperature.FrontLeft;
            car.TireTemperatureFR = data.tyreCoreTemperature.FrontRight;
            car.TireTemperatureRL = data.tyreCoreTemperature.RearLeft;
            car.TireTemperatureRR = data.tyreCoreTemperature.RearRight;

            car.TireConditionFL = data.tyreWear.FrontLeft / 100f;
            car.TireConditionFR = data.tyreWear.FrontRight / 100f;
            car.TireConditionRL = data.tyreWear.RearLeft / 100f;
            car.TireConditionRR = data.tyreWear.RearRight / 100f;

            car.TireDirtLevelFL = data.tyreDirtyLevel.FrontLeft;
            car.TireDirtLevelFR = data.tyreDirtyLevel.FrontRight;
            car.TireDirtLevelRL = data.tyreDirtyLevel.RearLeft;
            car.TireDirtLevelRR = data.tyreDirtyLevel.RearRight;

            car.TirePressureFL = psiToKpa(data.wheelsPressure.FrontLeft);
            car.TirePressureFR = psiToKpa(data.wheelsPressure.FrontRight);
            car.TirePressureRL = psiToKpa(data.wheelsPressure.RearLeft);
            car.TirePressureRR = psiToKpa(data.wheelsPressure.RearRight);

            car.SuspensionCamberFL = data.camberRAD.FrontLeft;
            car.SuspensionCamberFR = data.camberRAD.FrontRight;
            car.SuspensionCamberRL = data.camberRAD.RearLeft;
            car.SuspensionCamberRR = data.camberRAD.RearRight;

            car.BrakeTemperatureFL = data.brakeTemp.FrontLeft;
            car.BrakeTemperatureFR = data.brakeTemp.FrontRight;
            car.BrakeTemperatureRL = data.brakeTemp.RearLeft;
            car.BrakeTemperatureRR = data.brakeTemp.RearRight;

            car.Speed = data.speedKmh / 3.6f;
            car.Throttle = data.gas;
            car.Brake = data.brake;
            car.SteeringAngle = data.steerAngle;

            car.CarAccelerationLongitudinal = data.carAcceleration.Z * 9.81f;
            car.CarAccelerationLateral = data.carAcceleration.X * 9.81f;
        }

        protected override void writeDriverValues(Driver driver, AssettoCorsa.SPageFilePhysics data)
        {

        }

        protected override void writeSessionValues(Session session, AssettoCorsa.SPageFilePhysics data)
        {
        }
    }
}
