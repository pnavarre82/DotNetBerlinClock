using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.Classes.Tests
{
    [TestClass()]
    public class BerlinClockParserTests
    {
        BerlinClockParser berlinClockParser;
        PrivateObject berlinClockParserWhiteBox;
        int randomHour;
        int randomMinute;
        int randomSecond;

        [TestInitialize]
        public void init()
        {
            berlinClockParser = new BerlinClockParser();
            berlinClockParserWhiteBox = new PrivateObject(berlinClockParser);
            var randomGenerator = new Random();
            randomHour = randomGenerator.Next(0, 24);
            randomMinute = randomGenerator.Next(0, 59);
            randomSecond = randomGenerator.Next(0, 59);
        }

        [TestMethod()]
        public void parseFirstLine_ShouldParseY_IfEven()
        {
            var providedTime = new TimeSpan(randomHour, randomMinute, randomSecond * 2);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseFirstLine", providedTime);
            var expected = "Y";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseFirstLine_ShouldParse0_IfOdd()
        {
            var providedTime = new TimeSpan(randomHour, randomMinute, randomSecond * 2 + 1);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseFirstLine", providedTime);
            var expected = "O";
            Assert.AreEqual(expected, result);
        }


        [TestMethod()]
        public void parseSecondLine_ShouldParseOOOO_If00()
        {
            var providedTime = new TimeSpan(0, randomMinute, randomSecond);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseSecondLine", providedTime);
            var expected = "OOOO";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseSecondLine_ShouldParseRROO_If13()
        {
            var providedTime = new TimeSpan(13, randomMinute, randomSecond);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseSecondLine", providedTime);
            var expected = "RROO";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseSecondLine_ShouldParseRRRR_If23()
        {
            var providedTime = new TimeSpan(23, randomMinute, randomSecond);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseSecondLine", providedTime);
            var expected = "RRRR";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseSecondLine_ShouldParseRRRR_If2400()
        {
            var providedTime = new TimeSpan(24, 0, 0);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseSecondLine", providedTime);
            var expected = "RRRR";
            Assert.AreEqual(expected, result);
        }


        [TestMethod()]
        public void parseThirdLine_ShouldParseOOOO_If00()
        {
            var providedTime = new TimeSpan(0, randomMinute, randomSecond);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseThirdLine", providedTime);
            var expected = "OOOO";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseThirdLine_ShouldParseRRRO_If13()
        {
            var providedTime = new TimeSpan(13, randomMinute, randomSecond);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseThirdLine", providedTime);
            var expected = "RRRO";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseThirdLine_ShouldParseRRRO_If23()
        {
            var providedTime = new TimeSpan(23, randomMinute, randomSecond);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseThirdLine", providedTime);
            var expected = "RRRO";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseThirdLine_ShouldParseRRRR_If2400()
        {
            var providedTime = new TimeSpan(24, 0, 0);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseThirdLine", providedTime);
            var expected = "RRRR";
            Assert.AreEqual(expected, result);
        }


        [TestMethod()]
        public void parseFourthLine_ShouldParseOOOOOOOOOOO_If00()
        {
            var providedTime = new TimeSpan(randomHour, 0, randomSecond);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseFourthLine", providedTime);
            var expected = "OOOOOOOOOOO";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseFourthLine_ShouldParseYYROOOOOOOO_If17()
        {
            var providedTime = new TimeSpan(randomHour, 17, randomSecond);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseFourthLine", providedTime);
            var expected = "YYROOOOOOOO";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseFourthLine_ShouldParseYYRYYRYYRYY_If59()
        {
            var providedTime = new TimeSpan(randomHour, 59, randomSecond);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseFourthLine", providedTime);
            var expected = "YYRYYRYYRYY";
            Assert.AreEqual(expected, result);
        }


        [TestMethod()]
        public void parseFifthLine_ShouldParseOOOO_If00()
        {
            var providedTime = new TimeSpan(randomHour, 0, randomSecond);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseFifthLine", providedTime);
            var expected = "OOOO";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseFifthLine_ShouldParseYYOO_If17()
        {
            var providedTime = new TimeSpan(randomHour, 17, randomSecond);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseFifthLine", providedTime);
            var expected = "YYOO";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseFifthLine_ShouldParseYYYY_If59()
        {
            var providedTime = new TimeSpan(randomHour, 59, randomSecond);
            var result = (string)berlinClockParserWhiteBox.Invoke("parseFifthLine", providedTime);
            var expected = "YYYY";
            Assert.AreEqual(expected, result);
        }


        [TestMethod()]
        public void parseTimeToBerlinClockString_ShouldParse_If000000()
        {
            var providedTime = new TimeSpan(0, 0, 0);
            var result = berlinClockParser.parseTimeToClockString(providedTime);
            var expected =
@"Y
OOOO
OOOO
OOOOOOOOOOO
OOOO";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseTimeToBerlinClockString_ShouldParse_If131701()
        {
            var providedTime = new TimeSpan(13, 17, 1);
            var result = berlinClockParser.parseTimeToClockString(providedTime);
            var expected =
@"O
RROO
RRRO
YYROOOOOOOO
YYOO";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseTimeToBerlinClockString_ShouldParse_If235959()
        {
            var providedTime = new TimeSpan(23, 59, 59);
            var result = berlinClockParser.parseTimeToClockString(providedTime);
            var expected =
@"O
RRRR
RRRO
YYRYYRYYRYY
YYYY";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void parseTimeToBerlinClockString_ShouldParse_If240000()
        {
            var providedTime = new TimeSpan(24, 0, 0);
            var result = berlinClockParser.parseTimeToClockString(providedTime);
            var expected =
@"Y
RRRR
RRRR
OOOOOOOOOOO
OOOO";
            Assert.AreEqual(expected, result);
        }

    }
}