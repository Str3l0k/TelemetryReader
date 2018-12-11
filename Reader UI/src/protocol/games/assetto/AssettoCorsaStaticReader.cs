//using AssettoCorsaData;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using TelemetryReaderWpf.src.reader.impl;
//using TelemetryReader.src.protocol.datapool.categories;

//namespace TelemetryReader.src.protocol.games.assetto
//{
//    class AssettoCorsaStaticReader : SharedMemoryReader<AssettoCorsa.SPageFileStatic>
//    {
//        /* constructor */
//        public AssettoCorsaStaticReader() : base("acpmf_static", Marshal.SizeOf(typeof(AssettoCorsa.SPageFileStatic)))
//        {
//        }

//        protected override AssettoCorsa.SPageFileStatic initDataStruct()
//        {
//            return new AssettoCorsa.SPageFileStatic();
//        }

//        protected override void writeCarValues(Car car, AssettoCorsa.SPageFileStatic data)
//        {
//            car.RPMMax = data.maxRpm;
//            car.FuelCapacity = data.maxFuel;
//        }

//        protected override void writeDriverValues(Driver driver, AssettoCorsa.SPageFileStatic data)
//        {
//        }

//        protected override void writeSessionValues(Session session, AssettoCorsa.SPageFileStatic data)
//        {
//            session.DriversTotal = data.numCars;
//        }
//    }
//}
