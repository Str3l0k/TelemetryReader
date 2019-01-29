using Games;
using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows;
using Telemetry.Connection;
using Telemetry.Processing;
using Telemetry.Protocol.Datapool;
using Telemetry.Protocol.Transmission;
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
        private GameDict games = new GameDict();
        private GameObserver gameObserver;
        private GameDataWorker gameWorker;

        /* protocol transmission objects */
        private TransmitConnectionWrapper connections = new TransmitConnectionWrapper();
        private ProtocolPacketConverter packetConverter = new ProtocolPacketConverter();
        private ProtocolPacketHeader packetHeader = new ProtocolPacketHeader(2);

        #region init
        public Window1()
        {
            InitializeGameObserver();
            InitializeUI();
            InitializeComponent();

            var connection = new UDPConnection(new IPEndPoint(IPAddress.Parse("192.168.178.22"), 1337));
            var connection2 = new UDPConnection(new IPEndPoint(IPAddress.Parse("192.168.178.24"), 1337));

            connections.Add(connection);
            connections.Add(connection2);
        }

        private void InitializeUI()
        {
            this.Closing += Window1_Closing;
            this.Initialized += Window1_Initialized;
        }

        private void InitializeGameObserver()
        {
            gameObserver = new GameObserver(games.asArray);
            gameObserver.OnGameFound += OnGameFound;
            gameObserver.OnGameExited += OnGameExited;
        }
        #endregion

        #region Window events
        private void Window1_Initialized(object sender, EventArgs e)
        {
            Debug.WriteLine("Window 1 init");
            gameObserver.Start();
        }

        private void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            gameObserver.Stop();
            gameWorker.Stop();
        }
        #endregion

        #region GameObserver
        private void OnGameFound(Game game)
        {
            Debug.WriteLine($"Game found {game.Name}");
            gameObserver.Stop();

            // TODO check game id
            // TODO start worker based on found game

            StartWorker(game.ID);
        }

        private void OnGameExited(Game game)
        {
            Debug.WriteLine($"Game exited {game.Name}");
            gameWorker.Stop();
            gameObserver.Start();
        }
        #endregion

        #region Data work and processing
        private void StartWorker(GameID gameID)
        {
            gameWorker = games.WorkerForGame(gameID, connections, DataProcessor_OnDataProcessed);
            gameWorker.OnStarting += Worker_OnStarting;
            gameWorker.OnWorking += Worker_OnWorking;

            gameWorker.Start();
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
        #endregion

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
