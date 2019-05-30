using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector3<T>
    {
        public T X;
        public T Y;
        public T Z;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector4<T>
    {
        public T X;
        public T Y;
        public T Z;
        public T I;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TireData<T>
    {
        public T FrontLeft;
        public T FrontRight;
        public T RearLeft;
        public T RearRight;
    }
}
