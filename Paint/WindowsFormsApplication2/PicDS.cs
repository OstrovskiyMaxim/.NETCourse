using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class PicDS
    {
        List<IPicDS> ExtentionClassesList;

        public PicDS()
        {
            ExtentionClassesList = new List<IPicDS>();
            ExtentionClassesList.Add(new BitmapStandartSaver());
        }

        private string GetExtention(string path)
        {
            string extention = "";
            if (path != "")
            {
               extention = (path.Substring(path.LastIndexOf('.') + 1)).ToString().ToLower();
            }
            return extention;
        }

        public IPicDS GetInstance(string path)
        {
            string extension = GetExtention(path);
            if (extension == "jpg" || extension == "bmp" || extension == "gif" || extension == "png" || extension == "tiff" || extension == "ico")
            {
                extension = "bitmap";
            }
            foreach (IPicDS item in ExtentionClassesList)
            {
                if (item.IsYours(extension))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
