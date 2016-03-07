using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataRomainNumberParser.Tests
{
    [TestClass]
    public class RomanNumberGeneratorTest
    {
        [TestMethod]
        public void Given_1_Results_Into_I()
        {
            RomanNumberGenerator generator = new RomanNumberGenerator();
            string result = generator.Generate(1);

            Assert.AreEqual("I", result);
        }

        [TestMethod]
        public void Given_2_Results_Into_II()
        {
            RomanNumberGenerator generator = new RomanNumberGenerator();
            string result = generator.Generate(2);

            Assert.AreEqual("II", result);
        }

     

        [TestMethod]
        public void Given_4_Results_Into_IV()
        {
            RomanNumberGenerator generator = new RomanNumberGenerator();
            string result = generator.Generate(4);

            Assert.AreEqual("IV", result);
        }

        [TestMethod]
        public void Given_5_Results_Into_V()
        {
            RomanNumberGenerator generator = new RomanNumberGenerator();
            string result = generator.Generate(5);

            Assert.AreEqual("V", result);
        }


        [TestMethod]
        public void Given_8_Results_Into_VIII()
        {
            RomanNumberGenerator generator = new RomanNumberGenerator();
            string result = generator.Generate(8);

            Assert.AreEqual("VIII", result);
        }


        [TestMethod]
        public void Given_9_Results_Into_IX()
        {
            RomanNumberGenerator generator = new RomanNumberGenerator();
            string result = generator.Generate(9);

            Assert.AreEqual("IX", result);
        }

        [TestMethod]
        public void Given_10_Results_Into_X()
        {
            RomanNumberGenerator generator = new RomanNumberGenerator();
            string result = generator.Generate(10);

            Assert.AreEqual("X", result);
        }

        [TestMethod]
        public void Given_42_Results_Into_XLII()
        {
            RomanNumberGenerator generator = new RomanNumberGenerator();
            string result = generator.Generate(42);

            Assert.AreEqual("XLII", result);
        }

        [TestMethod]
        public void Given_99_Results_Into_XCIX()
        {
            RomanNumberGenerator generator = new RomanNumberGenerator();
            string result = generator.Generate(99);

            Assert.AreEqual("XCIX", result);
        }

        [TestMethod]
        public void Given_2013_Results_Into_MMXIII()
        {
            RomanNumberGenerator generator = new RomanNumberGenerator();
            string result = generator.Generate(2013);

            Assert.AreEqual("MMXIII", result);
        }

        [TestMethod]
        public void Given_72_Results_Into_LXXII()
        {
            RomanNumberGenerator generator = new RomanNumberGenerator();
            string result = generator.Generate(72);

            Assert.AreEqual("LXXII", result);
        }

    }
}
