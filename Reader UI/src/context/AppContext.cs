//using TelemetryReaderWpf.src.reader;

//namespace TelemetryReaderWpf.src
//{
//    public class AppContext
//    {
//        /* devices */
//        public Device device0 { get; private set; }
//        public Device device1 { get; private set; }
//        public Device device2 { get; private set; }

//        /* connections */
//        public Connection connection0 { get; private set; }
//        public Connection connection1 { get; private set; }
//        public Connection connection2 { get; private set; }

//        /* worker */
//        public Worker worker0 { get; private set; }
//        public Worker worker1 { get; private set; }
//        public Worker worker2 { get; private set; }

//        public AppContext(Preferences preferences)
//        {
//            init(preferences);
//        }

//        public void init(Preferences preferences)
//        {
//            device0 = new Device(preferences.ipEndpoint0, preferences.sendDelay0, true);
//            device1 = new Device(preferences.ipEndpoint1, preferences.sendDelay1, preferences.device1Enabled);
//            device2 = new Device(preferences.ipEndpoint2, preferences.sendDelay2, preferences.device2Enabled);

//            connection0 = new Connection(device0);
//            connection1 = new Connection(device1);
//            connection2 = new Connection(device2);

//            worker0 = new Worker(connection0, 0x0);
//            worker1 = new Worker(connection1, 0x1);
//            worker2 = new Worker(connection2, 0x2);
//        }

//        public void startWorkers()
//        {
//            if (device0.enabled && device0.ready && device0.ipAddress != null)
//            {
//                worker0.start();
//            }

//            if (device1.enabled && device1.ready && device1.ipAddress != null)
//            {
//                worker1.start();
//            }

//            if (device2.enabled && device2.ready && device2.ipAddress != null)
//            {
//                worker2.start();
//            }
//        }

//        public void stopWorkers()
//        {
//            worker0.stop();
//            worker1.stop();
//            worker2.stop();
//        }

//        public void setReaderToWorkers(Reader reader)
//        {
//            worker0.changeReader(reader);
//            worker1.changeReader(reader);
//            worker2.changeReader(reader);
//        }
//    }
//}
