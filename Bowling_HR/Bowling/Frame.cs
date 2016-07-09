using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Frame
    {
        private List<int> _pinsRolled;

        public Frame()
        {
            this._pinsRolled = new List<int>();
        }

        public List<int> PinsRolled
        {
            get
            {
                return this._pinsRolled;
            }
        }

        public int Score
        {
            get
            {
                return this._pinsRolled.Sum();
            }
        }

        public bool IsStrike
        {
            get
            {
                return this._pinsRolled.Count >= 1 && this._pinsRolled[0] == 10;
            }
        }

        public bool IsSpare
        {
            get
            {
                return this._pinsRolled.Count >= 2 && this._pinsRolled[0] + this._pinsRolled[1] == 10;
            }
        }        
    }
}
