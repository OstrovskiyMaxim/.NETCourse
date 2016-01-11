using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public interface IPicDS
    {
        void Save();
        Bitmap Load();
        string Ext { get; }
        bool IsYours(string extention);
        IPicDS Next{ get; set; }
    }
}
