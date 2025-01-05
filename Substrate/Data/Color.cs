using System.Runtime.InteropServices;

namespace Substrate.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Color
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public Color(byte r, byte g, byte b, byte a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
