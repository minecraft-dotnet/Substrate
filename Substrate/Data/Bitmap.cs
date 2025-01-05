using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Data
{
    public class Bitmap
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Color[] Data { get; private set; }

        public Color this[int x, int y]
        {
            get { return Data[y * Width + x]; }
            set { Data[y * Width + x] = value; }
        }

        public Bitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Data = new Color[width * height];
        }
    }
}
