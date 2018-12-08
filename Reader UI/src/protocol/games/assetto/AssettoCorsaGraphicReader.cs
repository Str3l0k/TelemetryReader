using AssettoCorsaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TelemetryReaderWpf.src.reader.impl;
using TelemetryReader.src.protocol.datapool.categories;

namespace TelemetryReader.src.protocol.games.assetto
{
    class AssettoCorsaGraphicReader : SharedMemoryReader<AssettoCorsa.SPageFileGraphic>
    {
        /* constructor */
        public AssettoCorsaGraphicReader() : base("acpmf_graphics", Marshal.SizeOf(typeof(AssettoCorsa.SPageFileGraphic)))
        {
        }

        protected override AssettoCorsa.SPageFileGraphic initDataStruct()
        {
            return new AssettoCorsa.SPageFileGraphic();
        }

        protected override void writeCarValues(Car car, AssettoCorsa.SPageFileGraphic data)
        {
            car.CarPositionBitfield(false, data.isInPit == 1, data.isInPitLane == 1, false, false, false);
        }

        protected override void writeDriverValues(Driver driver, AssettoCorsa.SPageFileGraphic data)
        {
            driver.PositonCurrent = data.position;
            driver.LapCurrent = data.completedLaps + 1;

            driver.LapTimeCurrent = data.iCurrentTime / 1000f;
            driver.LapTimeLast = data.iLastTime / 1000f;
            driver.LapTimeBestSession = data.iBestTime / 1000f;
        }

        protected override void writeSessionValues(Session session, AssettoCorsa.SPageFileGraphic data)
        {
            session.GameState = data.status;
            session.LapsTotal = data.numberOfLaps;
            if (float.IsNegativeInfinity(data.sessionTimeLeft) || float.IsInfinity(data.sessionTimeLeft))
            {
                session.EventTimeRemaining = 0;
            }
            else
            {
                session.EventTimeRemaining = data.sessionTimeLeft;
            }
        }
    }
}
