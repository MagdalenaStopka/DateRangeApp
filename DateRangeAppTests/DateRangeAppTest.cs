using System;
using System.Globalization;
using DateRangeApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateRangeAppTests
{
    [TestClass]
    public class DateRangeAppTest
    { 
        [TestMethod]
        public void TryParseDateToFormatTest()
        {
            string date = "24.12.1223";
            Program p = new Program();
            DateTime expectedDate = new DateTime(1223, 12, 24);
            DateTime actualDate = p.TryParseDateToFormat(date);
            Assert.AreEqual(expectedDate, actualDate);
        }
        static string startDate = "11.07.2005";
        static string endDate = "12.08.2005";

        DateTime _startDate = DateTime.ParseExact(startDate, "dd'.'MM'.'yyyy", CultureInfo.InvariantCulture);
        DateTime _endDate = DateTime.ParseExact(endDate, "dd'.'MM'.'yyyy", CultureInfo.InvariantCulture);

        [TestMethod]
        public void DateRangeTest()
        { 
            Program p = new Program();
            string expectedPeriod = "11.07 - 12.08.2005";
            string actualPeriod = p.DateRange(_startDate, _endDate);
            Assert.AreEqual(expectedPeriod, actualPeriod);
        }
        [TestMethod]
        public void CheckDateRangeTest()
        {
            Program p = new Program();
            bool actual = p.CheckDateRange(_startDate, _endDate);
            Assert.IsTrue(actual);
        }
    }
}