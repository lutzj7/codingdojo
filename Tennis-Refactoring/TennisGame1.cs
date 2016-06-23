using System;
using NUnit.Framework;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private static readonly string[] ScoreNames = { "Love", "Fifteen", "Thirty", "Forty" };
        private static readonly string[] TieNames = { "Love-All", "Fifteen-All", "Thirty-All", "Deuce" };

        private int _score1 = 0;
        private int _score2 = 0;
        private readonly string _player1Name;
        private readonly string _player2Name;

        private bool IsTie { get { return _score1 == _score2; } }
        private bool BothLowerForty { get { return _score1 < 4 && _score2 < 4; } }

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
            {
                _score1++;
            }
            else if (playerName == _player2Name)
            {
                _score2++;
            }
            else
            {
                throw new ArgumentException("Argument not valid");
            }
        }

        public string GetScore()
        {
            String score = "";
            if (IsTie)
            {
                score = GetScoreForTie();
            }
            else if (BothLowerForty)
            {
                score = string.Format("{0}-{1}",
                    GetScoreForSinglePlayer(_score1),
                    GetScoreForSinglePlayer(_score2));
            }
            else if (_score1 - _score2 >= 2)
            {
                score = string.Format("Win for {0}", _player1Name);
            }
            else if (_score2 - _score1 >= 2)
            {
                score = string.Format("Win for {0}", _player2Name);
            }
            else if (_score1 > _score2)
            {
                score = string.Format("Advantage {0}", _player1Name);
            }
            else if (_score2 > _score1)
            {
                score = string.Format("Advantage {0}", _player2Name);
            }

            return score;
        }

        private static string GetScoreForSinglePlayer(int tempScore)
        {
            if (tempScore < 0 || tempScore >= 4)
            {
                throw new ArgumentException("Operation not supported");
            }

            return ScoreNames[tempScore];
        }

        private string GetScoreForTie()
        {
            return TieNames[Math.Min(_score1,3)];
        }
    }

}

