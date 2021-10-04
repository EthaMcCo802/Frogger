using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Frogger
{
    class Logs
    {
        public int x, y, size, speed;
        public SolidBrush brushColor;

        public Logs(int _x, int _y, int _size, int _speed, SolidBrush _brushColor)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            brushColor = _brushColor;
        }
        public void Move()
        {
            y += speed;
        }
        public void Move(string direction)
        {
            y += speed;

        }
        
    }
}
