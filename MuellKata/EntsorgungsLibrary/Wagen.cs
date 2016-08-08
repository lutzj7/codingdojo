using System.Collections.Generic;

namespace EntsorgungsLibrary
{
    public class Wagen
    {
        public ColorBase Color { get; private set; }
        public List<Tonne> EmptyTrashCan { get; private set; } = new List<Tonne>();

        public Wagen(ColorBase color)
        {
            this.Color = color;
        }
    }
}