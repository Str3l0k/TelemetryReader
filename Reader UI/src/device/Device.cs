//using System;
//using System.Net;
//using System.Windows;
//using TelemetryReaderWpf.src.device;
//using TelemetryReaderWpf.src.ui;

//namespace TelemetryReaderWpf.src
//{
//    public delegate void ErrorOccured(object sender, EventArgs e);
//    public delegate void StateChanged(object sender, EventArgs e);

//    public class Device
//    {
//        /* connection info */
//        public IPEndPoint ipAddress { get; set; }
//        public int delay { get; private set; }

//        /* states */
//        public bool enabled { get; private set; }
//        public bool ready { get; private set; }
//        public bool active { get; private set; }
//        public bool error { get; private set; }

//        public DeviceUI deviceUI { get; set; }

//        /* events */
//        public event ErrorOccured errorOccured;
//        public event StateChanged stateChanged;

//        /* constructor */
//        public Device(IPEndPoint ip, int delayTime, bool enabled)
//        {
//            ipAddress = ip;
//            delay = delayTime;
//            reset();
//        }

//        public void enable()
//        {
//            enabled = true;
//            active = false;
//            error = false;

//            OnStateChanged();
//        }

//        public void disable()
//        {
//            enabled = false;
//            active = false;
//            error = false;

//            OnStateChanged();
//        }

//        public void ok()
//        {
//            ready = true;
//            error = false;

//            OnStateChanged();
//        }

//        public void fail()
//        {
//            ready = false;
//            active = false;
//            error = true;

//            OnErrorOccured();
//            OnStateChanged();
//        }

//        public void reset()
//        {
//            ready = true;
//            active = false;

//            OnStateChanged();
//        }

//        public void activate()
//        {
//            active = true;

//            OnStateChanged();
//        }

//        public void deactivate()
//        {
//            active = false;

//            OnStateChanged();
//        }

//        public void configureUI()
//        {
//            Application.Current.Dispatcher.Invoke(new Action(() => { UIController.configureDeviceUI(this); }));
//        }

//        private void OnErrorOccured()
//        {
//            errorOccured?.Invoke(this, EventArgs.Empty);
//        }

//        private void OnStateChanged()
//        {
//            stateChanged?.Invoke(this, EventArgs.Empty);
//        }
//    }
//}
