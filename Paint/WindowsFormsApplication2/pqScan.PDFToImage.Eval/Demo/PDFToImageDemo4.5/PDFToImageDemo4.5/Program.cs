using PQScan.PDFToImage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFToImageDemo4._5
{
    class Program
    {
        static void Main(string[] args)
        {
            toSinglePageImage();
            toMultipageImage();
        }

        private static void toSinglePageImage()
        {
            PDFDocument doc = new PDFDocument();

            doc.LoadPDF("F:/test.pdf");

            doc.DPI = 72;

            int count = doc.PageCount;

            for (int i = 0; i < count; i++)
            {
                Bitmap bmp = doc.ToImage(i);
                bmp.Save("F:/out" + i + ".png", ImageFormat.Png);

                Bitmap bmp1 = doc.ToImage(i, 80, 100);
                bmp1.Save("F:/out" + i + ".jpeg", ImageFormat.Jpeg);
            }

        }

        private static void toMultipageImage()
        {
            PDFDocument doc = new PDFDocument();

            doc.LoadPDF("F:/test.pdf");

            doc.DPI = 72;

            doc.ToMultiPageTiff("F:/multipage.tiff");
        }
    }
}
