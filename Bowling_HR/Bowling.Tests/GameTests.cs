using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bowling.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void UltiTest()
        {
            var game = new Game();
            Assert.IsFalse(game.Over);

            game.AddRoll(1);
            game.AddRoll(4);
            Assert.AreEqual(1, game.Frames.Count);
            Assert.AreEqual(5, game.Frames[0].Score);
            
            game.AddRoll(4);
            game.AddRoll(5);
            Assert.AreEqual(2, game.Frames.Count);
            Assert.AreEqual(9, game.Frames[1].Score);
            
            game.AddRoll(6);
            game.AddRoll(4);
            Assert.AreEqual(3, game.Frames.Count);
            Assert.AreEqual(10, game.Frames[2].Score);

            game.AddRoll(5);
            game.AddRoll(5);
            Assert.AreEqual(4, game.Frames.Count);
            Assert.AreEqual(15, game.Frames[2].Score);
            Assert.AreEqual(10, game.Frames[3].Score);

            game.AddRoll(10);
            Assert.AreEqual(5, game.Frames.Count);
            Assert.AreEqual(20, game.Frames[3].Score);
            Assert.AreEqual(10, game.Frames[4].Score);

            game.AddRoll(0);
            game.AddRoll(1);
            Assert.AreEqual(6, game.Frames.Count);
            Assert.AreEqual(1, game.Frames[5].Score);
            Assert.AreEqual(61, game.TotalScore);

            game.AddRoll(7);
            game.AddRoll(3);
            Assert.AreEqual(7, game.Frames.Count);
            Assert.AreEqual(10, game.Frames[6].Score);

            game.AddRoll(6);
            game.AddRoll(4);
            Assert.AreEqual(8, game.Frames.Count);
            Assert.AreEqual(16, game.Frames[6].Score);
            Assert.AreEqual(10, game.Frames[7].Score);

            game.AddRoll(10);
            Assert.AreEqual(9, game.Frames.Count);
            Assert.AreEqual(20, game.Frames[7].Score);
            Assert.AreEqual(10, game.Frames[8].Score);

            Assert.AreEqual(107, game.TotalScore);

            game.AddRoll(2);
            game.AddRoll(8);
            game.AddRoll(6);
            Assert.AreEqual(10, game.Frames.Count);
            Assert.AreEqual(20, game.Frames[8].Score);
            Assert.AreEqual(16, game.Frames[9].Score);

            Assert.AreEqual(133, game.TotalScore);
            Assert.IsTrue(game.Over);
        }

        [TestMethod]
        public void TripleStrike()
        {
            var game = new Game();
            game.AddRoll(10);

            Assert.AreEqual(10, game.TotalScore);

            game.AddRoll(10);

            Assert.AreEqual(30, game.TotalScore);

            game.AddRoll(10);

            Assert.AreEqual(60, game.TotalScore);
        }

        [TestMethod]
        public void PerfectGame()
        {
            var game = new Game();
            game.AddRoll(10);
            game.AddRoll(10);
            game.AddRoll(10);
            game.AddRoll(10);
            game.AddRoll(10);
            game.AddRoll(10);
            game.AddRoll(10);
            game.AddRoll(10);
            game.AddRoll(10);

            game.AddRoll(10);
            game.AddRoll(10);
            game.AddRoll(10);

            Assert.IsTrue(game.Over);
            Assert.AreEqual(300, game.TotalScore);
        }
    }
}
namespace Bowling.Tests
{
    [TestClass]
    public class OldTests
    {
        [TestMethod]
        public void CheckLengthOfFrameArrayAfterFirstRoll()
        {
            var game = new Game();
            game.AddRoll(1);
            var frames = game.Frames;
            Assert.AreEqual(1, frames.Count);
        }

        [TestMethod]
        public void CheckLengthOfFrameArrayAfterSecondRoll()
        {
            var game = new Game();
            game.AddRoll(1);
            game.AddRoll(4);
            var frames = game.Frames;
            Assert.AreEqual(1, frames.Count);
        }

        [TestMethod]
        public void CheckTotalScoreOfFrameArrayAfterSecondRoll()
        {
            var game = new Game();
            game.AddRoll(1);
            game.AddRoll(4);

            Assert.AreEqual(5, game.TotalScore);
        }

        [TestMethod]
        public void CheckTotalScoreOfFrameArrayAfterThirdRoll()
        {
            var game = new Game();
            game.AddRoll(1);
            game.AddRoll(4);
            game.AddRoll(4);

            Assert.AreEqual(9, game.TotalScore);
            var frames = game.Frames;
            Assert.AreEqual(2, frames.Count);
        }

        [TestMethod]
        public void CheckTotalScoreOfFrameArrayAfterFifthRoll()
        {
            var game = new Game();
            game.AddRoll(1);
            game.AddRoll(4);
            game.AddRoll(4);
            game.AddRoll(5);
            game.AddRoll(6);

            Assert.AreEqual(20, game.TotalScore);
            var frames = game.Frames;
            Assert.AreEqual(3, frames.Count);
            Assert.AreEqual(9, frames[1].Score);
        }

        [TestMethod]
        public void CheckTotalScoreOfFrameArrayAfterSeventhRoll()
        {
            var game = new Game();
            game.AddRoll(1);
            game.AddRoll(4);
            game.AddRoll(4);
            game.AddRoll(5);
            game.AddRoll(6);
            game.AddRoll(4);
            game.AddRoll(5);

            Assert.AreEqual(34, game.TotalScore);
            var frames = game.Frames;
            Assert.AreEqual(4, frames.Count);
            Assert.AreEqual(15, frames[2].Score);
        }

        [TestMethod]
        public void CheckTotalScoreOfFrameArrayAfterElevenRoll()
        {
            var game = new Game();

            game.AddRoll(1);
            game.AddRoll(4);

            game.AddRoll(4);
            game.AddRoll(5);

            game.AddRoll(6);
            game.AddRoll(4);

            game.AddRoll(5);
            game.AddRoll(5);

            game.AddRoll(10);

            game.AddRoll(0);
            game.AddRoll(1);

            Assert.AreEqual(61, game.TotalScore);
            var frames = game.Frames;
            Assert.AreEqual(6, frames.Count);
            Assert.AreEqual(1, frames[5].Score);
            Assert.AreEqual(2, frames[5].PinsRolled.Count);
        }

        [TestMethod]
        public void IsOver()
        {
            var game = new Game();
            game.AddRoll(1);
            game.AddRoll(4);

            game.AddRoll(4);
            game.AddRoll(5);

            game.AddRoll(6);
            game.AddRoll(4);

            game.AddRoll(5);
            game.AddRoll(5);

            game.AddRoll(10);

            game.AddRoll(0);
            game.AddRoll(1);

            game.AddRoll(7);
            Assert.IsFalse(game.Over);
            game.AddRoll(3);

            game.AddRoll(6);
            game.AddRoll(4);

            game.AddRoll(10);

            game.AddRoll(2);
            game.AddRoll(8);
            game.AddRoll(6);
            Assert.AreEqual(3, game.Frames[9].PinsRolled.Count);
            Assert.IsTrue(game.Over);
            Assert.AreEqual(133, game.TotalScore);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void ThrowingTooManyPinsCrashesTheBowlingAlley()
        {
            var game = new Game();
            game.AddRoll(11);
        }

    }
}

