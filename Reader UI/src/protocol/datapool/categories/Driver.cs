using System;

namespace TelemetryReader.src.protocol
{
    public class Driver : IDataWriter
    {
        /* decorated writer */
        private IDataWriter dataWriter;

        /* constructor */
        public Driver(IDataWriter dataWriter)
        {
            this.dataWriter = dataWriter;
        }

        #region decorator interface
        public void writeFloatValue(ushort ID, float value)
        {
            dataWriter.writeFloatValue(ID, value);
        }

        public void writeIntegerValue(ushort ID, int value)
        {
            dataWriter.writeIntegerValue(ID, value);
        }

        public void writeStringValue(ushort ID, string value)
        {
            dataWriter.writeStringValue(ID, value);
        }

        public void writeBitfieldValue(ushort ID, int bitfield)
        {
            dataWriter.writeBitfieldValue(ID, bitfield);
        }
        #endregion

        #region actual value properties

        #region session/event
        public int LapCurrent { set { writeIntegerValue(6192, value); } }
        public int PositonCurrent { set { writeIntegerValue(6190, value); } }
        #endregion

        #region timing
        #region lap
        public float LapTimeCurrent { set { writeFloatValue(6198, value); } }
        public float LapTimeLast { set { writeFloatValue(6199, value); } }
        public float LapTimeBestSession { set { writeFloatValue(6200, value); } }
        #endregion

        #region sector
        public float Sector1TimeCurrent { set { writeFloatValue(6203, value); } }
        public float Sector1TimeLast { set { writeFloatValue(6204, value); } }
        public float Sector1TimeBestSession { set { writeFloatValue(6205, value); } }
        public float Sector2TimeCurrent { set { writeFloatValue(6206, value); } }
        public float Sector2TimeLast { set { writeFloatValue(6207, value); } }
        public float Sector2TimeBestSession { set { writeFloatValue(6208, value); } }
        public float Sector3TimeCurrent { set { writeFloatValue(6209, value); } }
        public float Sector3TimeLast { set { writeFloatValue(6210, value); } }
        public float Sector3TimeBestSession { set { writeFloatValue(6211, value); } }
        public float SectorGeneralTimeLast { set { writeFloatValue(6212, value); } }
        #endregion

        #region opponent 
        public float DeltaTimeToOpponentAhead { set { writeFloatValue(6196, value); } }
        public float DeltaTimeToOpponentBehind { set { writeFloatValue(6197, value); } }
        #endregion

        #region pit
        #endregion
        #endregion

        #endregion
    }
}