using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using EntsorgungsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntsorgungsLibraryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitTourWithEmptyLists()
        {
            var tour = new Tour();
         
            tour.StarteTour( new List<Tonne>());
        }

        [TestMethod]
        public void SimpleTourTest()
        {
            var tour = new Tour();

            var greenTruck = new Wagen(new Green());
            var redTruck = new Wagen(new Red());

            tour.AddGarbageTruck(greenTruck);
            tour.AddGarbageTruck(redTruck);

            List<Tonne> volleTonnen = new List<Tonne>() {
                new Tonne(new Green()),
                new Tonne(new Green()),
                new Tonne(new Red()),
            };

            tour.StarteTour(volleTonnen);
            Assert.AreEqual(2, greenTruck.EmptyTrashCan.Count);
            Assert.AreEqual(1, redTruck.EmptyTrashCan.Count);
        }
    }
}
