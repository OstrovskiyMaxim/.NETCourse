using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Yaml.Serialization;

namespace Ball
{
    class YAML : IFormat
    {
        public List<MBall> From(string path)
        {
            var serializer = new YamlSerializer();
            StreamReader reader = new StreamReader(path);

            string yaml = reader.ReadToEnd();
            object obj = serializer.Deserialize(yaml)[0];
            return (obj as List<MBall>);
        }

        public void To(List<MBall> bouncingBalls, string path)
        {
            StreamReader reader = new StreamReader(path);
            var serializer = new YamlSerializer();
            string yaml = serializer.Serialize(bouncingBalls);
            File.WriteAllText(path, yaml);
        }
    }
}
