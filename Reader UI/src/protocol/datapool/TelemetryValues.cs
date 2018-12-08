using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelemetryReader.src.protocol.datapool.categories;

namespace TelemetryReader.src.protocol
{
    class TelemetryValues
    {
        /* category accessor properties */
        private Car car;
        private Driver driver;
        private Session session;
        private IDataWriter dataWriter;

        internal Car Car
        {
            get
            {
                return car;
            }
        }

        internal Driver Driver
        {
            get
            {
                return driver;
            }
        }

        internal Session Session
        {
            get
            {
                return session;
            }
        }

        TelemetryValues(IDataWriter dataWriter)
        {
            this.dataWriter = dataWriter;

            car = new Car(dataWriter);
            driver = new Driver(dataWriter);
            session = new Session(dataWriter);
        }
    }
}
