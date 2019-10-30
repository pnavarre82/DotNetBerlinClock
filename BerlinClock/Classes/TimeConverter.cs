namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private ITimeParser timeParser;
        private IClockParser clockParser;

        public TimeConverter()
        {
            // This constructor should not exist always use DI
            // added to avoid change the feature steps
            timeParser = new TimeParser();
            clockParser = new BerlinClockParser();
        }

        public TimeConverter(ITimeParser timeParser,
                             IClockParser clockParser)
        {
            this.timeParser = timeParser;
            this.clockParser = clockParser;
        }

        public string convertTime(string aTime)
        {
            var time = timeParser.parseTime(aTime);
            return clockParser.parseTimeToClockString(time);
        }
    }
}
