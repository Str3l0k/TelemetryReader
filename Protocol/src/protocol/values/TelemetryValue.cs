using System;

namespace Telemetry.Protocol
{
    public interface ITelemetryValue
    {
        UInt16 ID { get; }
        bool Changed { get; }
    }

    public class TelemetryValue<T> : ITelemetryValue
    {
        internal const int DefaultBufferLength = 3;

        /* properties */
        public UInt16 ID { get; private set; }
        bool ITelemetryValue.Changed
        {
            get => !Current.Equals(Previous);
        }

        private int CurrentIndex = 0;
        //private bool Changed = false;
        private T[] Values { get; set; }

        /* constructor */
        public TelemetryValue(ushort id)
        {
            this.ID = id;
            this.Values = new T[DefaultBufferLength];
        }

        public void Reset()
        {
            this.Values = new T[DefaultBufferLength];
        }

        #region indices
        private int NextIndex => (CurrentIndex + 1) % Values.Length;
        private int PreviousIndex => (CurrentIndex - 1) < 0 ? Values.Length - 1 : (CurrentIndex - 1);
        #endregion

        #region values
        public T Previous => Values[PreviousIndex];
        public T Current
        {
            get
            {
                //Changed = false;
                return Values[CurrentIndex];
            }
            set
            {
                //Changed = !Current.Equals(value);
                Values[NextIndex] = value;
                CurrentIndex = NextIndex;
            }
        }
        #endregion
    }
}
