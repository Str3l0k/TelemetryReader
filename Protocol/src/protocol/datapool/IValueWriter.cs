using System;

namespace Telemetry.Protocol.Datapool
{
    public interface IValueWriter
    {
        void WriteFloat(UInt16 id, float value);
        void WriteInteger(UInt16 id, int value);
        void WriteStringValue(UInt16 id, string value);
        void WriteBoolValue(UInt16 id, bool value);
    }
}
