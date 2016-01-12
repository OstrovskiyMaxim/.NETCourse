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
        void Save(string path, Bitmap saveBit);
        Bitmap Load(string path);
        string Ext { get; }
        bool IsYours(string extention);
    }
}
