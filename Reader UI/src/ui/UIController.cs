//using System;
//using System.Net;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Interop;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
////using TelemetryReaderWpf.src.device;

//namespace TelemetryReaderWpf.src.ui
//{
//    public class UIController
//    {
//        public static void selectRadioButton(RadioButton button1, RadioButton button2, RadioButton button3, int select)
//        {
//            button1.IsChecked = false;
//            button2.IsChecked = false;
//            button3.IsChecked = false;

//            switch (select)
//            {
//                case 30:
//                    button1.IsChecked = true;
//                    break;
//                case 12:
//                    button2.IsChecked = true;
//                    break;
//                case 7:
//                    button3.IsChecked = true;
//                    break;
//                default:
//                    button2.IsChecked = true;
//                    break;
//            }
//        }

//        public static int getSelectedRadioButton(RadioButton button1, RadioButton button2, RadioButton button3)
//        {
//            if (button1.IsChecked.Value)
//            {
//                return 30;
//            }
//            else if (button2.IsChecked.Value)
//            {
//                return 12;
//            }
//            else if (button3.IsChecked.Value)
//            {
//                return 7;
//            }

//            return 12;
//        }

//        private static bool checkIPInput(TextBox textBox, Device device)
//        {
//            try
//            {
//                if (device.ipAddress == null)
//                {
//                    device.ipAddress = new IPEndPoint(IPAddress.Parse(textBox.Text), 0);
//                }
//                else
//                {
//                    device.ipAddress.Address = IPAddress.Parse(textBox.Text);
//                }

//                textBox.Foreground = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));

//                return true;
//            }
//            catch (FormatException fe)
//            {
//                textBox.Foreground = new SolidColorBrush(Colors.Red);
//                return false;
//            }
//        }

//        private static bool checkPortInput(TextBox textBox, Device device)
//        {

//            try
//            {
//                device.ipAddress.Port = int.Parse(textBox.Text);
//                textBox.Foreground = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));

//                return true;
//            }
//            catch (FormatException fe)
//            {
//                textBox.Foreground = new SolidColorBrush(Colors.Red);
//                return false;
//            }
//            catch (ArgumentOutOfRangeException ae)
//            {
//                textBox.Foreground = new SolidColorBrush(Colors.Red);
//                return false;
//            }
//        }

//        private static void setButtonImage(Image image, Device device)
//        {
//            if (!device.active)
//            {
//                image.Source = Imaging.CreateBitmapSourceFromHBitmap(TelemetryReader.Properties.Resources.ic_play.GetHbitmap(),
//                        IntPtr.Zero,
//                        Int32Rect.Empty,
//                        BitmapSizeOptions.FromEmptyOptions());
//            }
//            else
//            {
//                image.Source = Imaging.CreateBitmapSourceFromHBitmap(TelemetryReader.Properties.Resources.ic_pause.GetHbitmap(),
//                        IntPtr.Zero,
//                        Int32Rect.Empty,
//                        BitmapSizeOptions.FromEmptyOptions());
//            }
//        }

//        public static void setPlayImage(Image image)
//        {
//            image.Source = Imaging.CreateBitmapSourceFromHBitmap(TelemetryReader.Properties.Resources.ic_play.GetHbitmap(),
//                        IntPtr.Zero,
//                        Int32Rect.Empty,
//                        BitmapSizeOptions.FromEmptyOptions());
//        }

//        /* new */
//        public static bool ipInputOK(TextBox textBox, Device device)
//        {
//            if (UIController.checkIPInput(textBox, device))
//            {
//                device.ok();
//                return true;
//            }
//            else
//            {
//                device.fail();
//                return false;
//            }
//        }

//        public static bool portInputOK(TextBox textBox, Device device)
//        {
//            if (UIController.checkPortInput(textBox, device))
//            {
//                device.ok();
//                return true;
//            }
//            else
//            {
//                device.fail();
//                return false;
//            }
//        }

//        public static void configureDeviceUI(Device device)
//        {
//            DeviceUI deviceUI = device.deviceUI;
//            // IP textbox
//            deviceUI.ipTextBox.IsEnabled = device.enabled && !device.active;
//            // port textbox
//            deviceUI.portTextBox.IsEnabled = device.enabled && !device.active;
//            // start button
//            deviceUI.startButton.IsEnabled = device.ready && !device.error && device.enabled;
//            // start button image
//            setButtonImage(deviceUI.startButtonImage, device);
//        }

//        public static void setGameLabel(Label gameLabel, AppContext context)
//        {
//            StringBuilder stringBuilder = new StringBuilder();

//            if (!context.gameSearcher.gameFound)
//            {
//                stringBuilder.Append("Waiting for game...");
//            }
//            else
//            {
//                stringBuilder.Append(context.gameSearcher.lastFoundGame.Name);
//            }

//            gameLabel.Content = stringBuilder.ToString();
//        }

//        public static void setStatusLabel(Label statusLabel, AppContext context)
//        {
//            StringBuilder stringBuilder = new StringBuilder("Status: ");

//            // TODO search and game status

//            if (context.device0.active)
//            {
//                stringBuilder.Append("Device 1");

//                if (context.worker0.dataHasBecomeAvailable)
//                {
//                    stringBuilder.Append(" sending");
//                }
//                else
//                {
//                    stringBuilder.Append(" waiting");
//                }
//            }

//            if (context.device1.active)
//            {
//                if (context.device0.active)
//                {
//                    stringBuilder.Append(" | ");
//                }

//                stringBuilder.Append("Device 2");

//                if (context.worker0.dataAvailable())
//                {
//                    stringBuilder.Append(" sending");
//                }
//                else
//                {
//                    stringBuilder.Append(" waiting");
//                }
//            }

//            if (context.device2.active)
//            {
//                if (context.device0.active || context.device1.active)
//                {
//                    stringBuilder.Append(" | ");
//                }

//                stringBuilder.Append("Device 3");

//                if (context.worker0.dataAvailable())
//                {
//                    stringBuilder.Append(" sending");
//                }
//                else
//                {
//                    stringBuilder.Append(" waiting");
//                }
//            }

//            if (!context.device0.active && !context.device1.active && !context.device2.active)
//            {
//                stringBuilder.Append("Idle");
//            }

//            statusLabel.Content = stringBuilder.ToString();
//        }
//    }
//}
