using System;

namespace Telemetry.Protocol.Datapool
{
    public interface IValueReader
    {
        int ReadInt(UInt16 id);
        float ReadFloat(UInt16 id);
        bool ReadBool(UInt16 id);
        string ReadString(UInt16 id);
    }
}
