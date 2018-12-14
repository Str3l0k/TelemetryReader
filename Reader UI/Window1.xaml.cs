using Games;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Shapes;
using Telemetry.Processing;
using Telemetry.Protocol.Datapool;
using Telemetry.Read;
using Telemetry.Utilities;

namespace TelemetryReader
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private double rectWidth = -1;

        /* control objects */
        private GameDict games;
        private GameObserver gameObserver;
        private GameDataWorker gameWorker;

        public Window1()
        {
            InitializeComponent();

            //Canvas.Children.Add();

            games = new GameDict();
            gameObserver = new GameObserver(games.asArray);
            gameObserver.OnGameFound += (game) =>
            {
                Debug.WriteLine($"Game found {game.Name}");
                gameObserver.Stop();

                if (game.ID == GameID.RaceRoomExperience)
                {
                    startR3EWorker();
                }
            };
            gameObserver.OnGameExited += (game) =>
            {
                Debug.WriteLine($"Game exited {game.Name}");
                gameObserver.Start();
            };

            gameObserver.Start();

            this.Closing += Window1_Closing;
        }

        private void startR3EWorker()
        {
            var dataReader = new SharedMemoryDataReader("$R3E", Marshal.SizeOf(typeof(Games.R3E.Data.Structure)));
            var dataProcessor = new RaceRoomDataProcessor();
            dataProcessor.processedCallback += DataProcessor_OnDataProcessed;

            gameWorker = new GameDataWorker(dataReader, dataProcessor);
            gameWorker.OnStarting += Worker_OnStarting;
            gameWorker.OnWorking += Worker_OnWorking;

            gameWorker.Start();
        }

        private void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            gameObserver.Stop();
            gameWorker.Stop();
        }

        private void DataProcessor_OnDataProcessed(TelemetryDatapool datapool)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                testLabel.Content = datapool.car.Gear;
                TestRect.Width = datapool.car.RPMPercentage * rectWidth;
                SpeedLabel.Content = (int)(datapool.car.Speed * 3.6);
            }));
        }

        private void Worker_OnWorking()
        {
            Debug.WriteLine("Worker now working.");
        }

        private void Worker_OnStarting()
        {
            Debug.WriteLine("Worker now starting.");
        }

        private void TestRect_Initialized(object sender, EventArgs e)
        {
            rectWidth = TestRect.ActualWidth;
        }

        private void TestRect_LayoutUpdated_1(object sender, EventArgs e)
        {
            if (rectWidth <= 0)
            {
                rectWidth = TestRect.ActualWidth;
            }
        }
    }
}
