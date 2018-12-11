//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.IO.MemoryMappedFiles;
//using TelemetryReader.src.protocol;

//namespace TelemetryReaderWpf.src.reader.impl
//{
//    public abstract class SharedMemoryReader<T> : GameReader<T>
//    {
//        /* shared memory information */
//        private string sharedMemoryName;
//        private int sharedMemorySize;

//        public int SharedMemorySize {  get { return sharedMemorySize; } }

//        /* shared memory objects */
//        private byte[] sharedMemoryBuffer;
//        private MemoryMappedFile sharedMemoryFile;
//        private MemoryMappedViewAccessor sharedMemoryAccessor;

//        private bool sharedMemoryFound;

//        private SendData sendData;

//        // TODO maybe game as reference instead of game id and bind size and offsets directly to game
//        public SharedMemoryReader(string name, int size)
//        {
//            sharedMemoryName = name;
//            sharedMemorySize = size;
//            sharedMemoryFound = false;

//            sharedMemoryBuffer = new byte[sharedMemorySize];

//            sendData = new SendData
//            {
//                data = sharedMemoryBuffer,
//                size = sharedMemoryBuffer.Length
//            };
//        }

//        public override bool dataAvailable()
//        {
//            if (sharedMemoryFile == null)
//            {
//                try
//                {
//                    sharedMemoryFile = MemoryMappedFile.OpenExisting(sharedMemoryName);
//                    sharedMemoryAccessor = sharedMemoryFile.CreateViewAccessor();

//                    sharedMemoryFound = true;
//                }
//                catch (FileNotFoundException e)
//                {
//                    sharedMemoryFound = false;
//                }
//            }

//            return sharedMemoryFound;
//        }

//        public override SendData Read()
//        {
//            sharedMemoryAccessor.ReadArray(0, sharedMemoryBuffer, 0, sharedMemoryBuffer.Length);            
//            marshalDataToStruct(sendData);
//            writeValues(data);
            
//            return protocolPacketData.getData(valueDictionary.Values);
//        }

//        public override void shutdown()
//        {
//            sharedMemoryAccessor.Dispose();
//            sharedMemoryFile.Dispose();
//        }
//    }
//}
