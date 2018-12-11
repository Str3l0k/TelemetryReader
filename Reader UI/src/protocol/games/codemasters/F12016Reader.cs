//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using TelemetryReader.src.protocol.datapool.categories;
//using TelemetryReader.src.reader.impl;

//namespace TelemetryReader.src.protocol.games.codemasters
//{
//    class F12016Reader : UDPDataReceiver<CodemastersData.F12016Packet>
//    {
//        public F12016Reader(int port) : base(port, Marshal.SizeOf(typeof(CodemastersData.F12016Packet)))
//        {
//        }

//        protected override CodemastersData.F12016Packet initDataStruct()
//        {
//            return new CodemastersData.F12016Packet();
//        }

//        protected override void writeCarValues(Car car, CodemastersData.F12016Packet data)
//        {
//            Console.WriteLine();
//        }

//        protected override void writeDriverValues(Driver driver, CodemastersData.F12016Packet data)
//        {
//        }

//        protected override void writeSessionValues(Session session, CodemastersData.F12016Packet data)
//        {
//        }
//    }
//}
