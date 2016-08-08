using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntsorgungsLibrary
{
    public abstract class ColorBase
    {

        public abstract string GetColor();

        public override int GetHashCode()
        {
            return GetColor().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            ColorBase otherColor =  obj as ColorBase;
           return otherColor != null && otherColor.GetColor() == this.GetColor();
        }

    }
}
