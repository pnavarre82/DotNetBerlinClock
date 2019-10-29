using System;

namespace BerlinClock.Classes
{
    public interface ITimeParser
    {
        TimeSpan parseTime(string stringTime);
    }
}
