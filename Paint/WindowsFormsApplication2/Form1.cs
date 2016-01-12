using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Paint : Form
    {
        Bitmap DrawArea;
        public Paint()
        {
            InitializeComponent();

            DrawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);

            trk_width.Minimum = 1;
            trk_width.Maximum = 9;
            trk_width.TickFrequency = 1;
        }

        int x;
        int y;
        bool flag = false;
        Color penColor = Color.Black;
        float penWidth = 1;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            flag = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                Graphics g = Graphics.FromImage(DrawArea);
                    //pictureBox1.CreateGraphics();
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawLine(new Pen(penColor, penWidth), x, y, e.X, e.Y);
                x = e.X;
                y = e.Y;
                pictureBox1.Image = DrawArea;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void Paint_Load(object sender, EventArgs e)
        {

        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            ColorDialog dialogColor = new ColorDialog();

            if (dialogColor.ShowDialog() == DialogResult.OK)
            {
                penColor = dialogColor.Color;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            penWidth = trk_width.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Image Files(*.BMP;)|*.BMP|Image Files(*.JPG;)|*.jpg|Image Files(*.GIF;)|*.gif|Image Files(*.PNG;)|*.png|Image Files(*.TIFF;)|*.tiff|Image Files(*.ICON;)|*.ico;";

            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            var savedBit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Bitmap saveBit = (Bitmap)pictureBox1.Image;

            pictureBox1.DrawToBitmap(savedBit, pictureBox1.ClientRectangle);

            PicDS saver = new PicDS();
            string path = saveFileDialog1.FileName;
            saver.GetInstance(path).Save(path, savedBit);

            savedBit.Dispose();
            saveFileDialog1.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;)|*.BMP|Image Files(*.JPG;)|*.jpg|Image Files(*.GIF;)|*.gif|Image Files(*.PNG;)|*.png|Image Files(*.TIFF;)|*.tiff|Image Files(*.ICON;)|*.ico;";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            PicDS saver = new PicDS();
            string path = openFileDialog1.FileName;
            Bitmap openedBit = saver.GetInstance(path).Load(path);

            Clear_Drawing_area();
            DrawArea = openedBit;
            pictureBox1.Image = DrawArea;
            openFileDialog1.Dispose();
            //openedBit.Dispose();
        }

        private void Clear_Drawing_area()
        {
            DrawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = DrawArea;
            this.Refresh();
        }
    }
}

