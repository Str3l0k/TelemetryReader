using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    public class GameData
    {
        public GameData(byte[] data)
        {
            this.RawData = data;
            this.RawSize = data.Length;
        }

        byte[] RawData { get; set; }
        int RawSize { get; set; }
    }
}
