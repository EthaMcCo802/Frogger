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
        public int x, y, width, height, speed;
        public SolidBrush brushColor;

        public Logs(int _x, int _y, int _width, int _height, int _speed, SolidBrush _brushColor)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            speed = _speed;
            brushColor = _brushColor;

        }
        public void Move()
        {
            x -= speed;
        }
        public void Move(string direction)
        {
            if (direction == "up")
            {
                y -= speed;

            }
            else if (direction == "down")
            {
                y += speed;
            }

        }

    }
}
