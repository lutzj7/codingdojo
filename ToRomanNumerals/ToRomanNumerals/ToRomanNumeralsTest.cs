using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToRomanNumerals
{
    [TestClass]
    public class ToRomanNumeralsTest    
    {
        private ToRomanNumerals _toRomanNumerals;

        [TestInitialize]
        public void InitializeTest()
        {
            _toRomanNumerals = new ToRomanNumerals();
        }

        [TestMethod]
        public void Decimal_1_Results_In_I()
        {
            Assert.AreEqual("I", _toRomanNumerals.Generate(1));
        }

        [TestMethod]
        public void Decimal_2_Results_In_II()
        {
            Assert.AreEqual("II", _toRomanNumerals.Generate(2));
        }

        [TestMethod]
        public void Decimal_4_Results_In_IV()
        {
            Assert.AreEqual("IV", _toRomanNumerals.Generate(4));
        }

        [TestMethod]
        public void Decimal_5_Results_In_V()
        {
            Assert.AreEqual("V", _toRomanNumerals.Generate(5));
        }


        [TestMethod]
        public void Decimal_9_Results_In_IX()
        {
            Assert.AreEqual("IX", _toRomanNumerals.Generate(9));
        }

        [TestMethod]
        public void Decimal_10_Results_In_X()
        {
            Assert.AreEqual("X", _toRomanNumerals.Generate(10));
        }

        [TestMethod]
        public void Decimal_42_Results_In_XLII()
        {
            Assert.AreEqual("XLII", _toRomanNumerals.Generate(42));
        }

        [TestMethod]
        public void Decimal_99_Results_In_XCIX()
        {
            Assert.AreEqual("XCIX", _toRomanNumerals.Generate(99));
        }

        [TestMethod]
        public void Decimal_2013_Results_In_MMXIII()
        {
            Assert.AreEqual("MMXIII", _toRomanNumerals.Generate(2013));
        }

        [TestMethod]
        public void Decimal_999_Results_In_CMXCIX()
        {
            Assert.AreEqual("CMXCIX", _toRomanNumerals.Generate(999));
        }

        [TestMethod]
        public void Decimal_1789_Results_In_MDCCLXXXIX()
        {
            Assert.AreEqual("MDCCLXXXIX", _toRomanNumerals.Generate(1789));
        }
    }

}
