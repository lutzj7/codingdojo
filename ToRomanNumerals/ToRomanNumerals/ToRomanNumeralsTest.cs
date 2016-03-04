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
    }

}
