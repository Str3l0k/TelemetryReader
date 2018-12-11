//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using TelemetryReader.src.protocol.datapool.categories;
//using TelemetryReaderWpf.src.reader.impl;

//namespace TelemetryReader.src.protocol.games.rfactor2
//{
//    class rFactor2TelemetryReader : SharedMemoryReader<rFactor2Data.telemetry>
//    {
//        /* constructor */
//        public rFactor2TelemetryReader() : base("rf2telemetrymmf", Marshal.SizeOf(typeof(rFactor2Data.telemetry)))
//        {
//        }

//        protected override rFactor2Data.telemetry initDataStruct()
//        {
//            return new rFactor2Data.telemetry();
//        }

//        protected override void writeCarValues(Car car, rFactor2Data.telemetry data)
//        {
            
//        }

//        protected override void writeDriverValues(Driver driver, rFactor2Data.telemetry data)
//        {
            
//        }

//        protected override void writeSessionValues(Session session, rFactor2Data.telemetry data)
//        {
            
//        }
//    }
//}
