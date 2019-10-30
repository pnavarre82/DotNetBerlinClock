using System;

namespace BerlinClock
{
    public interface IClockParser
    {
        string parseTimeToClockString(TimeSpan time);
    }
}
