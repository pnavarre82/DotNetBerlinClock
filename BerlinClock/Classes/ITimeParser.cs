using System;

namespace BerlinClock
{
    public interface ITimeParser
    {
        TimeSpan parseTime(string stringTime);
    }
}
