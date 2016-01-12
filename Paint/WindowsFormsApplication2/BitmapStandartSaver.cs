using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class BitmapStandartSaver : IPicDS
    {
        private IPicDS next;

        public IPicDS Next
        {
            get
            {
                return this.next;
            }

            set
            {
                this.next = value;
            }
        }

        public string Ext
        {
            get
            {
                return "bitmap";
            }
        }

        public bool IsYours(string extention)
        {
            if (extention == Ext)
            {
                return true;
            }
            return false;
        }

        public Bitmap Load(string path)
        {
            Bitmap openedBit = new Bitmap(path);
            return openedBit;
        }

        public void Save(string path, Bitmap Savebit)
        {
            string extention = (path.Substring(path.LastIndexOf('.') + 1)).ToString().ToLower();
            System.Drawing.Imaging.ImageFormat saveFormat = null;
            switch (extention)
            {
                case "jpg":
                    saveFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    break;
                case "bmp":
                    saveFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                    break;
                case "gif":
                    saveFormat = System.Drawing.Imaging.ImageFormat.Gif;
                    break;
                case "png":
                    saveFormat = System.Drawing.Imaging.ImageFormat.Png;
                    break;
                case "tiff":
                    saveFormat = System.Drawing.Imaging.ImageFormat.Tiff;
                    break;
                case "ico":
                    saveFormat = System.Drawing.Imaging.ImageFormat.Icon;
                    break;
            }
            Savebit.Save(path, saveFormat);
        }
    }
}
