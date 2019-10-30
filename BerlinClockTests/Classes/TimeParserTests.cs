using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.Classes.Tests
{
    [TestClass()]
    public class TimeParserTests
    {
        TimeParser timeParser;

        [TestInitialize]
        public void init()
        {
            timeParser = new TimeParser(); 
        }

        [TestMethod()]
        public void parseTime_ShouldParse_If000000()
        {
            var timeResult = timeParser.parseTime("00:00:00");
            var timeExpected = new TimeSpan(0, 0, 0);
            Assert.AreEqual(timeExpected, timeResult);
        }

        [TestMethod()]
        public void parseTime_ShouldParse_If131701()
        {
            var timeResult = timeParser.parseTime("13:17:01");
            var timeExpected = new TimeSpan(13, 17, 1);
            Assert.AreEqual(timeExpected, timeResult);
        }

        [TestMethod()]
        public void parseTime_ShouldParse_If235959()
        {
            var timeResult = timeParser.parseTime("23:59:59");
            var timeExpected = new TimeSpan(23, 59, 59);
            Assert.AreEqual(timeExpected, timeResult);
        }

        [TestMethod()]
        public void parseTime_ShouldParse_If240000()
        {
            // This should be ideally parsed to 00:00:00
            // and the clock should reset 24:00:00 == 00:00:00
            // done to be complaint with the feature, should be discussed later
            var timeResult = timeParser.parseTime("24:00:00");
            var timeExpected = new TimeSpan(24, 0, 0);
            Assert.AreEqual(timeExpected, timeResult);
        }


        [TestMethod()]
        [ExpectedException(typeof(Exception),
         "Parse time error time not valid 'Not valid'")]
        public void parseTime_ShouldRiseException_IfTimeNotParseable()
        {
            timeParser.parseTime("Not valid");
        }
    }
}