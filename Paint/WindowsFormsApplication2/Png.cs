﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Png : IPicDS
    {
        public string Ext
        {
            get
            {
                return "png";
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

        public Bitmap Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}