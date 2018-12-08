using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelemetryReader.src.protocol
{
    public class SendData
    {
        /* properties */
        public byte[] data { get; set; }
        public int size { get; set; }
        public short count { get; set; }

        /* constructor */
        public SendData()
        {
        }

        public SendData(byte[] data)
        {
            this.data = data;
            this.size = data.Length;
        }

        public SendData(int size)
        {
            this.data = new byte[size];
            this.size = size;
        }
    }
}
