using System;

namespace Telemetry.Protocol.Datapool
{
    public interface IValueWriter
    {
        void WriteFloat(UInt16 id, float value);
        void WriteInteger(UInt16 id, int value);
        void WriteString(UInt16 id, string value);
        void WriteBool(UInt16 id, bool value);
    }
}
