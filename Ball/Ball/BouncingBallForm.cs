using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Ball
{
    public partial class BouncingBallForm : Form
    {
        public BouncingBallForm()
        {
            InitializeComponent();
            timer1.Interval = 1000/30;
            g = CreateGraphics();
        }

        List<BouncingBallClass> bouncingBalls = new List<BouncingBallClass>();
        Graphics g;

        private void BouncingBallForm_MouseClick(object sender, MouseEventArgs e)
        {
            bouncingBalls.Add(new BouncingBallClass(e.X, e.Y));
            bouncingBalls[bouncingBalls.Count-1].DrawBall(g, this.ClientSize.Width, this.ClientSize.Height);
            timer1.Enabled = true;
        }

        private void MovingBall()
        {
            g.Clear(this.BackColor);
            for (int i = 0; i < bouncingBalls.Count; i++)
            {
                bouncingBalls[i].DrawBall(g, this.Width, this.Height);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MovingBall();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "XML files | *.xml | JSON files | *.json | CSV files | *.csv ";

            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            //var savedBit = new Bitmap(pictureBox.Width, pictureBox.Height);
            //pictureBox.DrawToBitmap(savedBit, pictureBox.ClientRectangle);
            string ext = saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.LastIndexOf('.') + 1);


            //switch (ext)
            //{
            //    //case "bmp":
            //    //    format = FileFormat.Bmp;
            //    //    break;
            //    //case "jpeg":
            //    //    format = ImageFormat.Jpeg;
            //    //    break;
            //    //case "tiff":
            //    //    format = ImageFormat.Tiff;
            //    //    break;
            //    //case "gif":
            //    //    format = ImageFormat.Gif;
            //    //    break;
            //    //case "png":
            //    //    format = ImageFormat.Png;
            //    //    break;
            //    //case "emf":
            //    //    format = ImageFormat.Emf;
            //    //    break;
            //    default:
            //        format = ImageFormat.Png;
            //        break;
            //}
            //savedBit.Save(saveFileDialog1.FileName);
            //savedBit.Dispose();
            //saveFileDialog1.Dispose();


            Saving s = new Saving();

             s.ToXML(bouncingBalls, saveFileDialog1.FileName);
            //s.ToJSON(bouncingBalls, saveFileDialog1.FileName);
            //s.ToCSV(bouncingBalls, saveFileDialog1.FileName);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Saving s = new Saving();

            openFileDialog1.Filter = "XML files | *.xml | JSON files | *.json | CSV files | *.csv ";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            bouncingBalls = s.FromXML(openFileDialog1.FileName);
            //XmlSerializer deserializer = new XmlSerializer(typeof(List<BouncingBallClass>));
            //TextReader reader = new StreamReader(openFileDialog1.FileName);
            //object obj = deserializer.Deserialize(reader);
            //List<BouncingBallClass> XmlData = (List<BouncingBallClass>)obj;
            //reader.Close();
            //bouncingBalls = XmlData;
            timer1.Start();
        }
    }
}
