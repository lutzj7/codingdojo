using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataRomainNumberParser.Tests
{
    [TestClass]
    public class RomanNumberParserTests
    {
        [TestMethod]
        public void Parsing_I_Results_In_1()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("I");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Parsing_II_Results_In_2()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("II");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Parsing_IV_Results_In_4()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("IV");
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Parsing_V_Results_In_5()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("V");
            Assert.AreEqual(5, result);
        }


        [TestMethod]
        public void Parsing_VIII_Results_In_8()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("VIII");
            Assert.AreEqual(8, result);
        }


        [TestMethod]
        public void Parsing_IX_Results_In_9()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("IX");
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Parsing_XLII_Results_In_42()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("XLII");
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void Parsing_XCIX_Results_In_99()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("XCIX");
            Assert.AreEqual(99, result);
        }


        [TestMethod]
        public void Parsing_MMXIII_Results_In_2013()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("MMXIII");
            Assert.AreEqual(2013, result);
        }


        [TestMethod]
        public void Parsing_MCMLXXXIII_Results_In_1983()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("MCMLXXXIII");
            Assert.AreEqual(1983, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parsing_IC_Results_In_ArgumentException()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("IC");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parsing_LC_Results_In_ArgumentException()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("LC");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parsing_DM_Results_In_ArgumentException()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("DM");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parsing_VX_Results_In_ArgumentException()
        {
            RomanNumberParser parser = new RomanNumberParser();
            int result = parser.Parse("VX");
        }


    }
}
