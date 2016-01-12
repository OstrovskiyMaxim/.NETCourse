using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ball
{
    class XML : IFormat
    {
        public void To(List<MBall> bouncingBalls, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<MBall>));
            FileStream file = File.Create(path);
            xmlSerializer.Serialize(file, bouncingBalls);
            file.Close();
        }

        public List<MBall> From(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<MBall>));
            StreamReader stringReader = new StreamReader(path);
            List<MBall> list = (List<MBall>)serializer.Deserialize(stringReader);
            return list;
        }
    }
}
