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

        List<BouncingBallClass> Balls = new List<BouncingBallClass>();
        Graphics g;

        private void BouncingBallForm_MouseClick(object sender, MouseEventArgs e)
        {
            Balls.Add(new BouncingBallClass(e.X, e.Y));
            Balls[Balls.Count-1].DrawBall(g, this.ClientSize.Width, this.ClientSize.Height);
            timer1.Enabled = true;
        }

        private void MovingBall()
        {
            g.Clear(this.BackColor);
            for (int i = 0; i < Balls.Count; i++)
            {
                Balls[i].DrawBall(g, this.Width, this.Height);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MovingBall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveState();
            saveFileDialog1.Filter = "XML files | *.xml | JSON files | *.json | CSV files | *.csv | YAML files | *.yaml ";

            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            string ext = saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.LastIndexOf('.') + 1);

            Factory cr = new Factory();
            cr.Format(ext.ToUpper());
            cr.To(mem.GetState, saveFileDialog1.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML files | *.xml | JSON files | *.json | CSV files | *.csv | YAML files | *.yaml ";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            string ext = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf('.') + 1);


            Factory cr = new Factory();
            cr.Format(ext.ToUpper());
            
            mem = new Momento(cr.From(openFileDialog1.FileName));
            LoadState();
            timer1.Start();
        }

        Momento mem;

        public void SaveState()
        {
            var list = new List<MBall>();
            foreach (var item in Balls)
            {
                list.Add(new MBall() { dx = item.dx, dy = item.dy, radius = item.radius, x = item.X, y = item.Y });
            }

            mem = new Momento(list);
        }

        public void LoadState()
        {
            Balls = new List<BouncingBallClass>();
            
            foreach (var item in mem.GetState)
            {
                Balls.Add(new BouncingBallClass() { dx = item.dx, dy = item.dy, radius = item.radius, X = item.x, Y = item.y });
            }
        }
    }
}
