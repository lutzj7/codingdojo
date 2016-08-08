using System;

namespace EntsorgungsLibrary
{
    public class Tonne
    {
        public ColorBase Color { get; private set; }
        public DateTime EmptyDate { get; set; }

         public Tonne(ColorBase color)
         {
             Color = color;
         }
    }
}