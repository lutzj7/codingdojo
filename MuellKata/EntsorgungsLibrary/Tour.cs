using System;
using System.Collections.Generic;

namespace EntsorgungsLibrary
{
    public class Tour
    {
        private List<Wagen> _wagen;

        private Dictionary<ColorBase, Wagen> _wagenMapping = new Dictionary<ColorBase, Wagen>();

        public void AddGarbageTruck(Wagen wagen)
        {
            _wagenMapping[wagen.Color] = wagen;
        }

        public void StarteTour(List<Tonne> volleTonnen )
        {
            foreach (Tonne tonne in volleTonnen)
            {
                var garbageTruck = _wagenMapping[tonne.Color];
                garbageTruck.EmptyTrashCan.Add(tonne);
            }        
        }
    }

}