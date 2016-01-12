using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    public class Momento
    {
        private List<MBall> list;

        public Momento(List<MBall> list)
        {
            this.list = list;
        }

        public List<MBall> GetState
        {
            get { return list;  }
        }
    }
}
