using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {
        private List<Frame> _frames;

        public Game()
        {
            this._frames = new List<Frame>();
        }

        public void AddRoll(int pins)
        {
            if (pins < 0 || pins > 10)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this._frames.Count == 0)
            {
                this._frames.Add(new Frame());
            }

            Frame last = this._frames.Last();

            if (((last.PinsRolled.Count == 1 && last.IsStrike)
                || (last.PinsRolled.Count == 2 && last.IsSpare)
                || (last.PinsRolled.Count == 2)) 
                && this._frames.Count < 10)
            {
                this._frames.Add(new Frame());
                last = this._frames.Last();
            }

            if (this._frames.Count >= 2)
            {
                var secondlast = this._frames[this._frames.Count - 2];

                if (secondlast.PinsRolled.Count < 3 &&
                    (secondlast.IsStrike || secondlast.IsSpare))
                {
                    secondlast.PinsRolled.Add(pins);
                }
            }

            last.PinsRolled.Add(pins);
        }

        public List<Frame> Frames
        {
            get
            {
                return this._frames;
            }
        }

        public int TotalScore
        {
            get
            {
                return this._frames.Sum(s => s.Score);
            }
        }

        public bool Over
        {
            get
            {
                return this._frames.Count == 10 && this._frames.Last().PinsRolled.Count >= 2;
            }
        }
    }
}
