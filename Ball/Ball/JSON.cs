using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    class JSON : IFormat
    {
        public void To(List<MBall> bouncingBalls, string path)
        {
            string json = JsonConvert.SerializeObject(bouncingBalls.ToArray());
            File.WriteAllText(path, json);
        }

        public List<MBall> From(string path)
        {
            StreamReader reader = new StreamReader(path);
            var list = reader.ReadToEnd();
            List<MBall> obj = JsonConvert.DeserializeObject<List<MBall>>(list);
            return obj;
        }
    }
}
