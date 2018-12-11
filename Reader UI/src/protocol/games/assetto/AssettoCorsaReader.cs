//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using AssettoCorsaData;
//using TelemetryReader.src.protocol.datapool.categories;
//using TelemetryReaderWpf.src.reader;
//using TelemetryReaderWpf.src.reader.impl;
//using System.Runtime.InteropServices;
//using TelemetryReader.src.protocol.games.assetto;

//namespace TelemetryReader.src.protocol.games
//{
//    class AssettoCorsaReader : Reader
//    {
//        private static readonly string PHYSICS = "SPageFilePhysics";
//        private static readonly string STATIC = "SPageFileStatic";
//        private static readonly string GRAPHIC = "SPageFileGraphic";

//        private AssettoCorsaPhysicsReader physicsReader;
//        private AssettoCorsaGraphicReader graphicReader;
//        private AssettoCorsaStaticReader staticReader;

//        private SendData sendData;

//        /* constructor */
//        public AssettoCorsaReader() : base()
//        {
//            this.physicsReader = new AssettoCorsaPhysicsReader();
//            this.graphicReader = new AssettoCorsaGraphicReader();
//            this.staticReader = new AssettoCorsaStaticReader();

//            int size = physicsReader.SharedMemorySize + graphicReader.SharedMemorySize + staticReader.SharedMemorySize;
//            this.sendData = new SendData(size);
//        }

//        public bool dataAvailable()
//        {
//            return physicsReader.dataAvailable() && graphicReader.dataAvailable() && staticReader.dataAvailable();
//        }

//        public SendData Read()
//        {
//            SendData physicsData = physicsReader.Read();
//            SendData graphicData = graphicReader.Read();
//            SendData staticData = staticReader.Read();

//            Buffer.BlockCopy(physicsData.data, 0, sendData.data, 0, physicsData.size);
//            Buffer.BlockCopy(graphicData.data, 0, sendData.data, physicsData.size, graphicData.size);
//            Buffer.BlockCopy(staticData.data, 0, sendData.data, physicsData.size + graphicData.size, staticData.size);

//            sendData.count = (short) (physicsData.count + graphicData.count + staticData.count);
//            sendData.size = physicsData.size + graphicData.size + staticData.size;

//            return sendData;
//        }

//        public void shutdown()
//        {
//            physicsReader.shutdown();
//            graphicReader.shutdown();
//            staticReader.shutdown();
//        }
//    }
//}
