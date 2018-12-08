using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelemetryReaderWpf.src.reader;

namespace TelemetryReader.src.protocol.games.rfactor2
{
    class rFactor2Reader : Reader
    {
        /* sub reader */
        private rFactor2TelemetryReader telemetryReader;
        private rFactor2ScoringReader scoringReader;

        /* combined send data */
        private SendData sendData;

        /* constructor */
        public rFactor2Reader()
        {
            this.telemetryReader = new rFactor2TelemetryReader();
            this.scoringReader = new rFactor2ScoringReader();

            this.sendData = new SendData(telemetryReader.SharedMemorySize + scoringReader.SharedMemorySize);
        }

        public bool dataAvailable()
        {
            return telemetryReader.dataAvailable() && scoringReader.dataAvailable();
        }

        public SendData Read()
        {
            SendData telemetry = telemetryReader.Read();
            SendData scoring = scoringReader.Read();

            Buffer.BlockCopy(telemetry.data, 0, sendData.data, 0, telemetry.size);
            Buffer.BlockCopy(scoring.data, 0, sendData.data, telemetry.size, telemetry.size);

            sendData.count = (short) (telemetry.count + scoring.count);

            return sendData;
        }

        public void shutdown()
        {
            telemetryReader.shutdown();
            scoringReader.shutdown();
        }
    }
}
