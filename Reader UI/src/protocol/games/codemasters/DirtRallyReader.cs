//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using TelemetryReader.src.protocol.datapool.categories;
//using TelemetryReader.src.reader.impl;

//namespace TelemetryReader.src.protocol.games.codemasters
//{
//    class DirtRallyReader : UDPDataReceiver<CodemastersData.DirtRallyPacket>
//    {
//        public DirtRallyReader(int port) : base(port, Marshal.SizeOf(typeof(CodemastersData.DirtRallyPacket)))
//        {
//        }

//        protected override CodemastersData.DirtRallyPacket initDataStruct()
//        {
//            return new CodemastersData.DirtRallyPacket();
//        }

//        protected override void writeCarValues(Car car, CodemastersData.DirtRallyPacket data)
//        {
//            car.Gear = (int) data.Gear;
//            car.RPM = R3EReader.rpsToRPM(data.RPM);
//            car.RPMMax = R3EReader.rpsToRPM(data.MaximumRPM);

//            car.BrakeTemperatureFL = data.TemperatureBrakeFrontLeft;
//            car.BrakeTemperatureFR = data.TemperatureBrakeFrontRight;
//            car.BrakeTemperatureRL = data.TemperatureBrakeRearLeft;
//            car.BrakeTemperatureRR = data.TemperatureBrakeRearRight;

//            car.Speed = data.VelocitySpeed;
//            car.CarAccelerationLateral = data.GForceLateral;
//            car.CarAccelerationLongitudinal = data.GForceLongitudinal;

//            car.Throttle = data.PositionThrottle;
//            car.Brake = data.PositionBrake;
//            car.Clutch = data.PositionClutch;
//        }

//        protected override void writeDriverValues(Driver driver, CodemastersData.DirtRallyPacket data)
//        {
//            driver.LapTimeCurrent = data.TimeCurrentLap;
//        }

//        protected override void writeSessionValues(Session session, CodemastersData.DirtRallyPacket data)
//        {
//        }
//    }
//}
