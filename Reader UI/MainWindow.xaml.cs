//using Games;
//using System;
//using System.Diagnostics;
//using System.Windows;
//using System.Windows.Input;
//using TelemetryReader.Properties;
//using TelemetryReader.src.protocol;
//using TelemetryReaderWpf.src;
//using TelemetryReaderWpf.src.device;
//using TelemetryReaderWpf.src.ui;

//namespace TelemetryReader
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        private AppContext context;

//        public MainWindow()
//        {
//            InitializeComponent();

//            context = new AppContext(createPreferences());

//            context.device0.deviceUI = new DeviceUI(IP_0_TextBox, Port_0_TextBox, start_Button_0, start_Image_0);
//            context.device1.deviceUI = new DeviceUI(IP_1_TextBox, Port_1_TextBox, start_Button_1, start_Image_1);
//            context.device2.deviceUI = new DeviceUI(IP_2_TextBox, Port_2_TextBox, start_Button_2, start_Image_2);

//            // TODO the delay selection
//            UIController.selectRadioButton(speed_Radio_00, speed_Radio_01, speed_Radio_02, context.device0.delay);
//            UIController.selectRadioButton(speed_Radio_10, speed_Radio_11, speed_Radio_12, context.device1.delay);
//            UIController.selectRadioButton(speed_Radio_20, speed_Radio_21, speed_Radio_22, context.device2.delay);

//            TextBoxConfiguration();
//            deviceCheckBoxConfiguration();
//            startButtonClickConfiguration();
//            deviceStateChangedConfiguration();
//            mainWindowConfiguration();

//            //var hwnd = new WindowInteropHelper(this).EnsureHandle();
//            //SourceInitialized += Window_SourceInitialized;
//            //Closing += Window_Closing;



//            start();
//        }
        
//        //[StructLayout(LayoutKind.Sequential)]
//        //internal struct RAWINPUTDEVICE
//        //{
//        //    [MarshalAs(UnmanagedType.U2)]
//        //    public ushort usUsagePage;
//        //    [MarshalAs(UnmanagedType.U2)]
//        //    public ushort usUsage;
//        //    [MarshalAs(UnmanagedType.U4)]
//        //    public int dwFlags;
//        //    public IntPtr hwndTarget;
//        //}

//        //private const int RIDEV_INPUTSINK = 0x00000100;

//        //[DllImport("User32.dll")]
//        //extern static bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevice, uint uiNumDevices, uint cbSize);

//        //private void Window_SourceInitialized(object sender, EventArgs e)
//        //{
//        //    IntPtr windowHandle = (new WindowInteropHelper(this)).Handle;
//        //    HwndSource source = HwndSource.FromHwnd(windowHandle);
//        //    source.AddHook(new HwndSourceHook(WndProc));

//        //    RAWINPUTDEVICE[] rid = new RAWINPUTDEVICE[1];

//        //    rid[0].usUsagePage = 0x01;
//        //    rid[0].usUsage = 0x02;
//        //    rid[0].dwFlags = RIDEV_INPUTSINK;
//        //    rid[0].hwndTarget = source.Handle;
//        //    RegisterRawInputDevices(rid, (uint)rid.Length, (uint)Marshal.SizeOf(rid[0]));

//        //    source.AddHook(new HwndSourceHook(WndProc));
//        //}

//        //private IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, ref bool result)
//        //{
//        //    // address the messages you are receiving using msg, wParam, lParam
//        //    //Debug.WriteLine("WNDPROC");

//        //    switch (msg)
//        //    {
//        //        case 0x00FF:
//        //            {
//        //                Debug.WriteLine("WM_INPUT received");
//        //            }
//        //            break; 
//        //    }

//        //    return IntPtr.Zero;
//        //}

//        //private void Window_Closing(object sender, EventArgs e)
//        //{
//        //    IntPtr windowHandle = (new WindowInteropHelper(this)).Handle;
//        //    HwndSource src = HwndSource.FromHwnd(windowHandle);
//        //    src.RemoveHook(new HwndSourceHook(this.WndProc));
//        //}

//        /* helper */
//        private Preferences createPreferences()
//        {
//            Preferences preferences = new Preferences();

//            //preferences.initIPs(Settings.Default.IP_0, Settings.Default.IP_1, Settings.Default.IP_2, Settings.Default.Port_0, Settings.Default.Port_1, Settings.Default.Port_2);
//            //preferences.initDeviceEnabled(true, Settings.Default.device_1_enabled, Settings.Default.device_2_enabled);
//            //preferences.initSendDelays(Settings.Default.send_delay_0, Settings.Default.send_delay_1, Settings.Default.send_delay_2);

//            return preferences;
//        }

//        private void updateStatusLabel()
//        {
//            Application.Current.Dispatcher.Invoke(new Action(() => { UIController.setStatusLabel(Status_Label, context); }));
//        }

//        private void updateGameLabel()
//        {
//            Application.Current.Dispatcher.Invoke(new Action(() => { UIController.setGameLabel(Game_Label, context); }));
//        }

//        /* event configuration */
//        private void TextBoxConfiguration()
//        {
//            IP_0_TextBox.TextChanged += (sender, e) =>
//            {
//                Port_0_TextBox.IsEnabled = UIController.ipInputOK(IP_0_TextBox, context.device0);
//            };

//            IP_1_TextBox.TextChanged += (sender, e) =>
//            {
//                Port_1_TextBox.IsEnabled = UIController.ipInputOK(IP_1_TextBox, context.device1);
//            };

//            IP_2_TextBox.TextChanged += (sender, e) =>
//            {
//                Port_2_TextBox.IsEnabled = UIController.ipInputOK(IP_2_TextBox, context.device2);
//            };

//            Port_0_TextBox.TextChanged += (sender, e) =>
//            {
//                if (UIController.ipInputOK(IP_0_TextBox, context.device0))
//                {
//                    UIController.portInputOK(Port_0_TextBox, context.device0);
//                }
//            };

//            Port_1_TextBox.TextChanged += (sender, e) =>
//            {
//                if (UIController.ipInputOK(IP_1_TextBox, context.device1))
//                {
//                    UIController.portInputOK(Port_1_TextBox, context.device1);
//                }
//            };

//            Port_2_TextBox.TextChanged += (sender, e) =>
//            {
//                if (UIController.ipInputOK(IP_2_TextBox, context.device2))
//                {
//                    UIController.portInputOK(Port_2_TextBox, context.device2);
//                }
//            };
//        }

//        private void deviceCheckBoxConfiguration()
//        {
//            device_1_checkbox.Checked += (sender, e) =>
//            {
//                context.device1.enable();
//                context.device1.configureUI();
//                updateStatusLabel();
//            };

//            device_1_checkbox.Unchecked += (sender, e) =>
//            {
//                context.device1.disable();
//                context.worker1.stop();
//                context.device1.configureUI();
//                updateStatusLabel();
//            };

//            device_2_checkbox.Checked += (sender, e) =>
//            {
//                context.device2.enable();
//                context.device2.configureUI();
//                updateStatusLabel();
//            };

//            device_2_checkbox.Unchecked += (sender, e) =>
//            {
//                context.device2.disable();
//                context.worker2.stop();
//                context.device2.configureUI();
//                updateStatusLabel();
//            };
//        }

//        private void startButtonClickConfiguration()
//        {
//            start_Button_0.MouseUp += (sender, e) =>
//            {
//                if (context.device0.active)
//                {
//                    context.worker0.stop();
//                }
//                else
//                {
//                    if (UIController.ipInputOK(IP_0_TextBox, context.device0) && UIController.portInputOK(Port_0_TextBox, context.device0))
//                    {
//                        context.worker0.start();
//                    }
//                }

//                context.device0.configureUI();
//                updateStatusLabel();
//            };

//            start_Button_1.MouseUp += (sender, e) =>
//            {
//                if (context.device1.active)
//                {
//                    context.worker1.stop();
//                }
//                else
//                {
//                    if (UIController.ipInputOK(IP_1_TextBox, context.device1) && UIController.portInputOK(Port_1_TextBox, context.device1))
//                    {
//                        context.worker1.start();
//                    }
//                }

//                context.device1.configureUI();
//                updateStatusLabel();
//            };

//            start_Button_2.MouseUp += (sender, e) =>
//            {
//                if (context.device2.active)
//                {
//                    context.worker2.stop();
//                }
//                else
//                {
//                    if (UIController.ipInputOK(IP_2_TextBox, context.device2) && UIController.portInputOK(Port_2_TextBox, context.device2))
//                    {
//                        context.worker2.start();
//                    }
//                }

//                context.device2.configureUI();
//                updateStatusLabel();
//            };
//        }

//        private void deviceStateChangedConfiguration()
//        {
//            context.device0.enable();

//            context.device0.stateChanged += (sender, e) =>
//            {
//                context.device0.configureUI();
//                updateStatusLabel();
//            };

//            context.device1.stateChanged += (sender, e) =>
//            {
//                context.device1.configureUI();
//                updateStatusLabel();
//            };

//            context.device2.stateChanged += (sender, e) =>
//            {
//                context.device2.configureUI();
//                updateStatusLabel();
//            };
//        }

//        private void mainWindowConfiguration()
//        {
//            Main_Window.Closing += (sender, e) =>
//            {
//                stop();
//                save();
//            };

//            Main_Bar.MouseDown += (sender, e) =>
//            {
//                if (e.ChangedButton.Equals(MouseButton.Left))
//                {
//                    DragMove();
//                }
//            };

//            Minimize_Button.Click += (sender, e) =>
//            {
//                WindowState = WindowState.Minimized;
//            };

//            Close_Button.Click += (sender, e) =>
//            {
//                Close();
//            };
//        }

//        /* UI methods */
//        private void start()
//        {
//            context.worker0.onDataAvailable += (sender, e) => { updateStatusLabel(); };
//            context.worker1.onDataAvailable += (sender, e) => { updateStatusLabel(); };
//            context.worker2.onDataAvailable += (sender, e) => { updateStatusLabel(); };

//            context.device0.configureUI();
//            context.device1.configureUI();
//            context.device2.configureUI();

//            //Port_0_TextBox.IsEnabled = UIController.ipInputOK(IP_0_TextBox, context.device0);
//            //Port_1_TextBox.IsEnabled = UIController.ipInputOK(IP_1_TextBox, context.device1);
//            //Port_2_TextBox.IsEnabled = UIController.ipInputOK(IP_2_TextBox, context.device2);

//            updateStatusLabel();

//            /* auto start game search */
//            context.gameSearcher.onGameFound += (sender, e) =>
//            {
//                Debug.WriteLine("Game found: " + context.gameSearcher.lastFoundGame.Name);
//                updateGameLabel();

//                Game game = context.gameSearcher.lastFoundGame;
//                ProtocolReader protocolTestReader = new ProtocolReader(game.ID);
//                protocolTestReader.reader = context.gameSearcher.lastFoundGame.reader;
//                context.setReaderToWorkers(protocolTestReader);
//                context.startWorkers();
//            };

//            context.gameSearcher.onGameExited += (sender, e) =>
//            {
//                Debug.WriteLine("Game exited. Restarting search.");
//                context.stopWorkers();
//                context.gameSearcher.start();
//                updateGameLabel();
//            };

//            context.gameSearcher.start();
//        }

//        private void stop()
//        {
//            /* stop all workers */
//            context.stopWorkers();

//            /* stop search if active */
//            context.gameSearcher.stop();
//        }

//        private void save()
//        {
//            // save active devices
//            Settings.Default.device_1_enabled = device_1_checkbox.IsChecked.Value;
//            Settings.Default.device_2_enabled = device_2_checkbox.IsChecked.Value;

//            // save ips
//            Settings.Default.IP_0 = IP_0_TextBox.Text;
//            Settings.Default.IP_1 = IP_1_TextBox.Text;
//            Settings.Default.IP_2 = IP_2_TextBox.Text;

//            // save ports
//            try
//            {
//                Settings.Default.Port_0 = Int32.Parse(Port_0_TextBox.Text);
//            }
//            catch (FormatException e)
//            {
//                Settings.Default.Port_0 = 1337;
//            }

//            try
//            {
//                Settings.Default.Port_1 = Int32.Parse(Port_1_TextBox.Text);
//            }
//            catch (FormatException e)
//            {
//                Settings.Default.Port_1 = 1337;
//            }

//            try
//            {
//                Settings.Default.Port_2 = Int32.Parse(Port_2_TextBox.Text);
//            }
//            catch (FormatException e)
//            {
//                Settings.Default.Port_2 = 1337;
//            }


//            // save send delays
//            Settings.Default.send_delay_0 = UIController.getSelectedRadioButton(speed_Radio_00, speed_Radio_01, speed_Radio_02);
//            Settings.Default.send_delay_1 = UIController.getSelectedRadioButton(speed_Radio_10, speed_Radio_11, speed_Radio_12);
//            Settings.Default.send_delay_2 = UIController.getSelectedRadioButton(speed_Radio_20, speed_Radio_21, speed_Radio_22);

//            Settings.Default.Save();
//        }
//    }
//}
