using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bowling.Tests
{
    [TestClass]
    public class FrameTests
    {
        Frame frame;
        [TestInitialize]
        public void CreateFrame()
        {
            frame = new Frame();
        }

        [TestMethod]
        public void AllZero()
        {
            RepeatSameRoll(pins: 0, count: 20);
            ExpectScoreToBe(0);
        }       

        [TestMethod]
        public void AllOne()
        {
            RepeatSameRoll(pins: 1, count: 20);
            ExpectScoreToBe(20);
        }

        [TestMethod]
        public void OneSpare()
        {
            Roll(8, 2, 9, 0);
            RepeatSameRoll(pins: 0, count: 16);
            ExpectScoreToBe(8 + 2 + 9 * 2);
        }

        [TestMethod]
        public void OneStrike()
        {
            Roll(10,10,10,7,2);
            RepeatSameRoll(pins: 0, count: 16);
            ExpectScoreToBe(85);
        }

        [TestMethod]
        public void PerfectGame()
        {
            RepeatSameRoll(pins: 10, count: 12);
            ExpectScoreToBe(300);
        }

        [TestMethod]
        public void FullTest()
        {
            Roll(10, 10, 10, 7, 2, 8, 2, 0, 9, 10, 7, 3, 9, 0);//, 10, 10, 8);
            ExpectScoreToBe(152);
        }

        /// <summary>
        /// Private Methods
        /// </summary>
        /// 
        private void Roll(params int[] pins)
        {
            foreach (var pin in pins)
            {
                frame.Roll(pin);
            }
        }

        private void RepeatSameRoll(int pins, int count)
        {
            for (int i = 0; i < count; i++)
            {
                frame.Roll(pins);
            }
        }

        private void ExpectScoreToBe(int expectedscore)
        {
            int score = frame.GetScore();
            Assert.AreEqual(expectedscore, score);
        }       
    }
}
