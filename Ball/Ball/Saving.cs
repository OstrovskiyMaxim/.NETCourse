using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace Ball
{
    class Saving
    {
        public void ToXML(List<BouncingBallClass> bouncingBalls, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<BouncingBallClass>));
            FileStream file = File.Create(path);
            xmlSerializer.Serialize(file, bouncingBalls);
            file.Close();
        }

        public List<BouncingBallClass> FromXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<BouncingBallClass>));

                 StreamReader stringReader = new StreamReader(path);
                List<BouncingBallClass> obj = (List<BouncingBallClass>) serializer.Deserialize(stringReader);
            

            return obj;
        }


        public void ToJSON(List<BouncingBallClass> bouncingBalls, string path)
        {
            string json = JsonConvert.SerializeObject(bouncingBalls.ToArray());
            File.WriteAllText(path, json);
        }


        public void ToCSV(List<BouncingBallClass> bouncingBalls, string path)
        {
            using (var file = File.CreateText(path))
            {
                foreach (var ball in bouncingBalls)
                {
                    file.WriteLine(string.Join(",", ball.dx));
                    file.WriteLine(string.Join(",", ball.dy));
                    file.WriteLine(string.Join(",", ball.radius));
                    file.WriteLine(string.Join(",", ball.X));
                    file.WriteLine(string.Join(",", ball.Y));
                }
            }
        }

    }
}
