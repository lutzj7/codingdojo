using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataRomanNumbers
{
    [TestClass]
    public class RomanNumbersTest
    {
        private RomanNumbersParser _parser;

        [TestInitialize]
        public void Init()
        {
            _parser = new RomanNumbersParser();
        }

        [TestMethod]
        public void Roman_I_gives_1()
        {
            Assert.AreEqual(1, _parser.Parse("I"));
        }

        [TestMethod]
        public void Roman_II_gives_2()
        {
            Assert.AreEqual(2, _parser.Parse("II"));
        }

        [TestMethod]
        public void Roman_IV_gives_4()
        {
            Assert.AreEqual(4, _parser.Parse("IV"));
        }

        [TestMethod]
        public void Roman_V_gives_5()
        {
            Assert.AreEqual(5, _parser.Parse("V"));
        }

        [TestMethod]
        public void Roman_IX_gives_9()
        {
            Assert.AreEqual(9, _parser.Parse("IX"));
        }

        [TestMethod]
        public void Roman_XLII_gives_42()
        {
            Assert.AreEqual(42, _parser.Parse("XLII"));
        }

        [TestMethod]
        public void Roman_XCIX_gives_99()
        {
            Assert.AreEqual(99, _parser.Parse("XCIX"));
        }

        [TestMethod]
        public void Roman_MMXIII_gives_2013()
        {
            Assert.AreEqual(2013, _parser.Parse("MMXIII"));
        }

        [TestMethod]
        public void Roman_MMXIII_gives_1789()
        {
            Assert.AreEqual(1789, _parser.Parse("MDCCLXXXIX"));
        }
    }

}
