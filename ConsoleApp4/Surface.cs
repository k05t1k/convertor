using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Surface
    {
        public string Name;
        public int Width;
        public int Height;
        public Surface(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
        }
        public Surface() { }
    }
}
