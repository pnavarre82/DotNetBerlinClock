using System;

namespace BerlinClock.Classes
{
    public class TimeParser: ITimeParser
    {
        public TimeSpan parseTime(string stringTime)
        {
            try
            {
                var spliteTime = stringTime.Split(':');
                var hours = int.Parse(spliteTime[0]);
                var minutes = int.Parse(spliteTime[1]);
                var seconds = int.Parse(spliteTime[2]);
                return new TimeSpan(hours, minutes, seconds);

            }
            catch
            {
                throw new Exception($"Parse time error time not valid '{stringTime}'");
            }
        }
    }
}
