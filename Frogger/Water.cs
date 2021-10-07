using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Frogger
{
    class Water
    {
        public int x, y, width, height;
        public SolidBrush brushColor;
        public Water(int _x, int _y, int _width, int _height, SolidBrush _brushColor)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            brushColor = _brushColor;
        }
    }
}
