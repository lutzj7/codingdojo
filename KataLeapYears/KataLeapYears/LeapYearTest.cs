using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataLeapYears
{
    //A leap year is divisible by 4, but is not otherwise divisible by 100 unless it is also divisible by 400.
    //2001 is a typical common year
    //1996 is a typical leap year
    //1900 is an atypical common year 
    //2000 is an atypical leap year
    [TestClass]
    public class LeapYearTest
    {
        [TestMethod]
        public void Year_2001_no_leapyear()
        {
            Assert.IsFalse(LeapYear.IsLeapyear(2001));
        }

        [TestMethod]
        public void Year_1996_is_LeapYear()
        {
            Assert.IsTrue(LeapYear.IsLeapyear(1996));
        }

        [TestMethod]
        public void Year_1900_no_leapyear()
        {
            Assert.IsFalse(LeapYear.IsLeapyear(1900));
        }

        [TestMethod]
        public void Year_2000_is_LeapYear()
        {
            Assert.IsTrue(LeapYear.IsLeapyear(2000));
        }

        [TestMethod]
        public void Year_0_no_leapyear()
        {
            Assert.IsFalse(LeapYear.IsLeapyear(0));
        }
    }

    public class LeapYear
    {
        public static bool IsLeapyear(int year)
        {
            return year > 0 && ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0);
        }
    }
}
