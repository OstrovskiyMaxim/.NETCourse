using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    interface IFormat
    {
        void To(List<MBall> bouncingBalls, string path);
        List<MBall> From(string path);
    }
}
