using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    public interface IGameDataProcessor
    {
        void ProcessData(GameData data);
    }
}
