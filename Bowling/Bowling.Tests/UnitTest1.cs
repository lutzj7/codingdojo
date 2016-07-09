using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bowling.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckLengthOfFrameArrayAfterFirstRoll()
        {
            var game = new Game();
            game.AddRoll(1);
            var frames = game.Frames();
            Assert.AreEqual(1, frames.Length);
        }

        [TestMethod]
        public void CheckLengthOfFrameArrayAfterSecondRoll()
        {
            var game = new Game();
            game.AddRoll(1);
            game.AddRoll(4);
            var frames = game.Frames();
            Assert.AreEqual(1, frames.Length);
        }

        [TestMethod]
        public void CheckTotalScoreOfFrameArrayAfterSecondRoll()
        {
            var game = new Game();
            game.AddRoll(1);
            game.AddRoll(4);

            Assert.AreEqual(5, game.TotalScore());
        }

        [TestMethod]
        public void CheckTotalScoreOfFrameArrayAfterThirdRoll()
        {
            var game = new Game();
            game.AddRoll(1);
            game.AddRoll(4);
            game.AddRoll(4);

            Assert.AreEqual(9, game.TotalScore());
            var frames = game.Frames();
            Assert.AreEqual(2, frames.Length);
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

            Assert.AreEqual(20, game.TotalScore());
            var frames = game.Frames();
            Assert.AreEqual(3, frames.Length);
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

            Assert.AreEqual(34, game.TotalScore());
            var frames = game.Frames();
            Assert.AreEqual(4, frames.Length);
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

            Assert.AreEqual(61, game.TotalScore());
            var frames = game.Frames();
            Assert.AreEqual(6, frames.Length);
            Assert.AreEqual(1, frames[5].Score);
            Assert.AreEqual(2, frames[5].PinsRolled.Length);
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
            Assert.IsFalse(game.Over());
            game.AddRoll(3);

            game.AddRoll(6);
            game.AddRoll(4);

            game.AddRoll(10);

            game.AddRoll(2);
            game.AddRoll(8);
            game.AddRoll(6);
            Assert.AreEqual(3, game.Frames()[9].PinsRolled.Length);
            Assert.IsTrue(game.Over());
            Assert.AreEqual(133, game.TotalScore());
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
