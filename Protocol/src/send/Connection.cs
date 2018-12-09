using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.src.send
{
    interface IConnection
    {
        void Send(byte[] data);
    }
}
