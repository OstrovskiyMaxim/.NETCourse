using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    public class BouncingBallClass
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int dx, dy;
        public int radius;
        Color color;

        public BouncingBallClass()
        {

        }

        public BouncingBallClass(int x, int y)
        {
            Random rannd = new Random();
            this.X = x;
            this.Y = y;
            dx = rannd.Next(-15, 15);
            dy = rannd.Next(-15, 15);
            while (dy==0)
            {
                dy = rannd.Next(-50, 50);
            }
            while (dx==0)
            {
                dx = rannd.Next(-50, 50);
            }
            color = Color.FromArgb(rannd.Next(255), rannd.Next(255), rannd.Next(255));
            while (color==Color.White)
            {
                color = Color.FromArgb(rannd.Next(255), rannd.Next(255), rannd.Next(255));
            }
            radius = rannd.Next(1, 100);
        }

        public void DrawBall(Graphics g, int width, int height)
        {
            FindNewXY(width, height);
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, X, Y, radius, radius);
            X = X + dx;
            Y = Y + dy;
        }

        private void FindNewXY(int width, int height)
        {
            if (X< 0 || X +2*radius >width)
            {
                dx = -dx;
                X = X<0?0:width-2*radius;
                Y = Y+dy;
            }
            if (Y< 0 || Y+2*radius+25>height)
            {
                dy = -dy;
                Y = Y < 0 ?0 : height-2*radius-25;
                X = X + dx;
            }
        }

    }
}
