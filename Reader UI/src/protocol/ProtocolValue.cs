using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelemetryReader.src.protocol
{
    public class ProtocolValue
    {
        public static readonly sbyte FLOAT = 0x1;
        public static readonly sbyte INTEGER = 0x2;
        public static readonly sbyte STRING = 0x3;

        public UInt16 ID { get; set; }
        public sbyte type { get; set; }

        protected ProtocolValue(UInt16 ID)
        {
            this.ID = ID;
        }
    }

    class ProtocolValue<T> : ProtocolValue
    {        
        public T value { get; set; }

        public ProtocolValue(ushort ID) : base(ID)
        {
            sbyte type = -1;
            
            if (typeof(T) == typeof(float))
            {
                type = FLOAT;
            }
            else if(typeof(T) == typeof(int))
            {
                type = INTEGER;
            }
            else if(typeof(T) == typeof(string))
            {
                type = STRING;
            }

            this.type = type;
        }

        public ProtocolValue(sbyte type, ushort ID) : base(ID)
        {
            this.type = type;
        }
    }
}
