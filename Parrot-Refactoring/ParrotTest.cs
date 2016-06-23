using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace parrot
{
    [TestClass]
    public class ParrotTest
    {
        [TestMethod]
        public void GetSpeedOfEuropeanParrot()
        {
            var parrot = new EuropeanParrot();
            Assert.AreEqual(12.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedOfAfricanParrot_With_One_Coconut()
        {
            var parrot = new AfricanParrot(1);
            Assert.AreEqual(3.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedOfAfricanParrot_With_Two_Coconuts()
        {
            var parrot = new AfricanParrot(2);
            Assert.AreEqual(0.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedOfAfricanParrot_With_No_Coconuts()
        {
            var parrot = new AfricanParrot(0);
            Assert.AreEqual(12.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedNorwegianBlueParrot_nailed()
        {
            var parrot = new NorwegianBlueParrot(0, true);
            Assert.AreEqual(0.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedNorwegianBlueParrot_not_nailed()
        {
            var parrot = new NorwegianBlueParrot(1.5, false);
            Assert.AreEqual(18.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedNorwegianBlueParrot_not_nailed_high_voltage()
        {
            var parrot = new NorwegianBlueParrot(4, false);
            Assert.AreEqual(24.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetListOfParrots()
        {
            var parrots = new List<Parrot>();
            parrots.Add(new AfricanParrot(1));
            parrots.Add(new EuropeanParrot());
            parrots.Add(new AfricanParrot(42));
            parrots.Add(new NorwegianBlueParrot(3.14159, true));
            
            Assert.AreEqual(15, parrots.Sum(parrot => parrot.GetSpeed()));

        }
    }
}
