using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    [Serializable]
    public class MBall
    {
        public int x;
        public int y;
        public int dx, dy;
        public int radius;

        public MBall()
        {

        }

        public MBall(int dx, int dy, int radius, int x, int y)
        {
            this.dx = dx;
            this.dy = dy;
            this.radius = radius;
            this.x = x;
            this.y = y;
        }
    }
}

