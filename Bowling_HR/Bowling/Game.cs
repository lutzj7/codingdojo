using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {
        private const int MINPINS = 0;
        private const int MAXPINS = 10;

        private const int SECOND = 2;
        private const int THIRD = 3;

        private List<Frame> _frames;

        public Game()
        {
            this._frames = new List<Frame>();
        }

        public void AddRoll(int pins)
        {
            if (pins < MINPINS || pins > MAXPINS)
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
            
            last.PinsRolled.Add(pins);

            this.PinsImputeByStrikeOrSpare(pins, SECOND);
            this.PinsImputeByStrikeOrSpare(pins, THIRD);
        }

        private void PinsImputeByStrikeOrSpare(int pins, int frameCount)
        {
            if (this._frames.Count >= frameCount)
            {
                var frame = this._frames[this._frames.Count - frameCount];

                if (frame.PinsRolled.Count < 3 &&
                    (frame.IsStrike || frame.IsSpare))
                {
                    frame.PinsRolled.Add(pins);
                }
            }
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
