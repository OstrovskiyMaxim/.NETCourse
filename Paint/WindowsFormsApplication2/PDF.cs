using PQScan.ImageToPDF;
using PQScan.PDFToImage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class PDF : IPicDS
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
                return "pdf";
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
            PDFDocument pdfDoc = new PDFDocument();
            string fileName = path.Remove(path.LastIndexOf('.') + 1) + ".pdf";
            pdfDoc.LoadPDF(fileName);
            Bitmap openedBit = pdfDoc.ToImage(0);

            return openedBit;
        }

        public void Save(string path, Bitmap saveBit)
        {
            PDFConverter converter = new PDFConverter();
            converter.PageSizeType = PageSizeMode.A4;

            string extention = (path.Substring(path.LastIndexOf('.') + 1)).ToString().ToLower();
            string JpegFileName = path.Substring(0, (path.LastIndexOf('.') + 1)).ToString() + ".jpg";
            saveBit.Save(JpegFileName, ImageFormat.Jpeg);

            converter.CreatePDF(new string[] { JpegFileName }, path);
        }
    }
}
