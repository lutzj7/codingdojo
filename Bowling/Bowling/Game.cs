using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {
        private List<Frame> _frames = new List<Frame>();

        public void AddRoll(int pins)
        {
            if (pins > 10 || pins < 0)
                throw new ArgumentOutOfRangeException("bla");

            if (this._frames.Count == 10 && this._frames[9].PinsRolled.Length == 2)
            {
                this._frames[9].PinsRolled = new[] {
                    this._frames[9].PinsRolled[0],
                    this._frames[9].PinsRolled[1],
                    pins
                };
                this._frames[9].Score += pins;
            }

            else
            {
                if (this._frames.Count == 0
                    || _frames[_frames.Count - 1].PinsRolled.Length == 2
                    || _frames[_frames.Count - 1].Score == 10
                    )
                {
                    this._frames.Add(new Frame
                    {
                        PinsRolled = new[] { pins },
                        Score = pins
                    });
                }
                else
                {

                    _frames[_frames.Count - 1].PinsRolled = new[] {
                        _frames[_frames.Count - 1].PinsRolled[0],
                        pins
                    };

                    _frames[_frames.Count - 1].Score += pins;
                }

                if (_frames.Count > 1 && (_frames[_frames.Count - 2].Score == 10 || _frames[_frames.Count - 2].PinsRolled.Length == 1))
                {
                    _frames[_frames.Count - 2].Score += pins;
                }
            }
        }

        public Frame[] Frames()
        {
            return this._frames.ToArray();
        }
        public int TotalScore()
        {
            return _frames.Sum(frame => frame.Score);
        }
        public bool Over()
        {
            if (this._frames.Count < 10
                || this._frames[9].PinsRolled.Length < 2)
            {
                return false;
            }

            if (this._frames[9].PinsRolled.Length == 2 && this._frames[9].PinsRolled.Sum() >= 10)
            {
                return false;
            }

            return true;
        }
    }

}
