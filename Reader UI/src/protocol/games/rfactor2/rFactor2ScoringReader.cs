using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TelemetryReader.src.protocol.datapool.categories;
using TelemetryReaderWpf.src.reader.impl;

namespace TelemetryReader.src.protocol.games.rfactor2
{
    class rFactor2ScoringReader : SharedMemoryReader<rFactor2Data.scoring>
    {
        /* constructor */
        public rFactor2ScoringReader() : base("rf2scoringmmf", Marshal.SizeOf(typeof(rFactor2Data.scoring)))
        {
        }

        protected override rFactor2Data.scoring initDataStruct()
        {
            return new rFactor2Data.scoring();
        }

        protected override void writeCarValues(Car car, rFactor2Data.scoring data)
        {
            
        }

        protected override void writeDriverValues(Driver driver, rFactor2Data.scoring data)
        {
            
        }

        protected override void writeSessionValues(Session session, rFactor2Data.scoring data)
        {
            
        }
    }
}
