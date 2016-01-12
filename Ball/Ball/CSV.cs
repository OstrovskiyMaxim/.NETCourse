using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    class CSV : IFormat
    {
        public void To(List<MBall> bouncingBalls, string path)
        {
            using (var file = File.CreateText(path))
            {
                foreach (var ball in bouncingBalls)
                {
                    file.WriteLine(string.Join(",", ball.dx));
                    file.WriteLine(string.Join(",", ball.dy));
                    file.WriteLine(string.Join(",", ball.radius));
                    file.WriteLine(string.Join(",", ball.x));
                    file.WriteLine(string.Join(",", ball.y));
                }
            }
        }

        public List<MBall> From(string path)
        {
            List<MBall> obj = new List<MBall>();
            StreamReader reader = new StreamReader(path);

            int[] tempArr = new int[5];
            int i = 0;

            while (reader.Peek() >= 0)
            {
                tempArr[i++] = Convert.ToInt32(reader.ReadLine());

                if (i == 5)
                {
                    obj.Add(new MBall(tempArr[0], tempArr[1], tempArr[2], tempArr[3], tempArr[4]));
                    i = 0;
                }
            }

            return obj;
        }
    }
}
