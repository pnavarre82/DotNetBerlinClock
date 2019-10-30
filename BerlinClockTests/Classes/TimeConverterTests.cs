using Microsoft.VisualStudio.TestTools.UnitTesting;
using BerlinClock.Classes;
using Moq;
using System;

namespace BerlinClock.Tests
{
    [TestClass()]
    public class TimeConverterTests
    {
        TimeConverter timeConverter;
        Mock<ITimeParser> timeParserMock;
        Mock<IClockParser> clockParserMock;
        TimeSpan timeParserResult = new TimeSpan(2, 2, 2);
        string clockParserResult = "for";
        string timeStringToConvert = "bar";

        [TestInitialize]
        public void init()
        {
            setupTimeParserMock();
            setupClockParserMock();
            timeConverter = new TimeConverter(
                timeParserMock.Object,
                clockParserMock.Object);

        }

        private void setupTimeParserMock()
        {
            timeParserMock = new Mock<ITimeParser>();
            timeParserMock.Setup(mock => mock.parseTime(timeStringToConvert))
                .Returns((string _) => timeParserResult);
        }

        private void setupClockParserMock()
        {
            clockParserMock = new Mock<IClockParser>();
            clockParserMock.Setup(mock => mock.parseTimeToClockString(timeParserResult))
                .Returns((TimeSpan _) => clockParserResult);
        }

        [TestMethod()]
        public void convertTime_ShouldInvokeDependentFunctions()
        {
            var result = timeConverter.convertTime(timeStringToConvert);

            timeParserMock.Verify(mock => mock.parseTime(timeStringToConvert), Times.Once());
            clockParserMock.Verify(mock => mock.parseTimeToClockString(timeParserResult), Times.Once());

            Assert.AreEqual(result, clockParserResult);
        }
    }
}