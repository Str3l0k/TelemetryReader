using System;
using System.Net;

namespace TelemetryReaderWpf.src
{
    public class Preferences
    {
        public IPEndPoint ipEndpoint0 { get; private set; }
        public IPEndPoint ipEndpoint1 { get; private set; }
        public IPEndPoint ipEndpoint2 { get; private set; }

        public bool device0Enabled { get; private set; }
        public bool device1Enabled { get; private set; }
        public bool device2Enabled { get; private set; }

        public int sendDelay0 { get; private set; }
        public int sendDelay1 { get; private set; }
        public int sendDelay2 { get; private set; }

        public Preferences()
        {
        }

        public void initIPs(string ip0, string ip1, string ip2, int port0, int port1, int port2)
        {
            ipEndpoint0 = parseIP(ip0, port0);
            ipEndpoint1 = parseIP(ip1, port1);
            ipEndpoint2 = parseIP(ip2, port2);
        }

        public void initDeviceEnabled(bool device0, bool device1, bool device2)
        {
            device0Enabled = device0;
            device1Enabled = device1;
            device2Enabled = device2;
        }

        public void initSendDelays(int delay0, int delay1, int delay2)
        {
            sendDelay0 = delay0;
            sendDelay1 = delay1;
            sendDelay2 = delay2;
        }

        public int getDelayTimeFromCode(int delayCode)
        {
            switch (delayCode)
            {
                case 0:
                    return 30;
                case 2:
                    return 10;
                case 1:
                default:
                    return 20;
            }
        }

        private IPEndPoint parseIP(string ip, int port)
        {
            try
            {
                return new IPEndPoint(IPAddress.Parse(ip), port);
            }
            catch (FormatException fe)
            {
                return null;
            }
        }
    }
}


