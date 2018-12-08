namespace TelemetryReader.src.protocol
{
    public class Session
    {
        /* decorated writer */
        private IDataWriter dataWriter;

        /* constructor */
        public Session(IDataWriter dataWriter)
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

        #region event
        public int LapsTotal { set { writeIntegerValue(10262, value); } }
        public int DriversTotal { set { writeIntegerValue(10242, value); } }
        #endregion

        #region game session
        public int SessionID { set { writeIntegerValue(10244, value); } }
        public int SessionState { set { writeIntegerValue(10248, value); } }
        public int GameState { set { writeIntegerValue(10274, value); } }
        #endregion

        #region timing
        public float EventTimeRemaining { set { writeFloatValue(10290, value); } }
        public float EventTimeElapsed { set { writeFloatValue(10289, value); } }
        #endregion

        #region weather
        public float AmbientTemperature { set { writeFloatValue(10253, value); } }
        public float TrackTemperatureAround { set { writeFloatValue(10307, value); } }
        #endregion

        #endregion
    }
}