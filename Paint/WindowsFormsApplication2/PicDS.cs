using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class PicDS
    {
        IPicDS root;
        public PicDS()
        {
            root = new Jpeg();

            IPicDS temp = root;
            temp.Next = new Png();

            temp = temp.Next;
            temp.Next = new Bmp();
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
            IPicDS nodeNow = root;
            while (nodeNow != null)
            {
                if(nodeNow.Ext == extension)
                {
                    return nodeNow;
                }
                nodeNow = nodeNow.Next;
            }
            return null;
        }
    }
}
