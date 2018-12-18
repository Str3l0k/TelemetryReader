using System.Runtime.InteropServices;

namespace Telemetry.Utilities
{
    public static class StructMarshal
    {
        public static void MarshalRawDataToStruct<T>(byte[] data, ref T result)  {
            var size = Marshal.SizeOf(typeof(T));

            var ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(data, 0, ptr, data.Length);
            result = (T) Marshal.PtrToStructure(ptr, result.GetType());
            Marshal.FreeHGlobal(ptr);
        }

        public static bool MarshalStructToRawData<T>(T obj, ref byte[] data, int dstOffset)
        {
            var objSize = Marshal.SizeOf(typeof(T));

            var ptr = Marshal.AllocHGlobal(objSize);
            Marshal.StructureToPtr(obj, ptr, false);
            Marshal.Copy(ptr, data, dstOffset, objSize);
            Marshal.FreeHGlobal(ptr);

            return true;
        }
    }
}
