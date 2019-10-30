using System;
using System.Text;

namespace BerlinClock
{
    public class BerlinClockParser: IClockParser
    {
        const char InactiveLight = 'O';
        const char YellowLight = 'Y';
        const string HoursAllLights = "RRRR";
        const string MinutesAllLights = "YYRYYRYYRYY";
        const string MinutesModuluesAllLights = "YYYY";
        const int HoursEachUpperLightRepresent = 5;
        const int MinutesEachUpperLightRepresent = 5;

        public string parseTimeToClockString(TimeSpan time)
        {
            var berlinClockStringBuilder = new StringBuilder();
            berlinClockStringBuilder.AppendLine(parseFirstLine(time));
            berlinClockStringBuilder.AppendLine(parseSecondLine(time));
            berlinClockStringBuilder.AppendLine(parseThirdLine(time));
            berlinClockStringBuilder.AppendLine(parseFourthLine(time));
            berlinClockStringBuilder.Append(parseFifthLine(time));

            return berlinClockStringBuilder.ToString();
        }

        private string parseFirstLine(TimeSpan time)
        {
            return time.Seconds % 2 == 1
            ? InactiveLight.ToString()
            : YellowLight.ToString();
        }

        private string parseSecondLine(TimeSpan time)
        {
            var elapsedHours = getElapsedHours(time);
            var numberOfActiveLights = Math.Min(HoursEachUpperLightRepresent, elapsedHours / HoursEachUpperLightRepresent);
            return getHoursLightsString(numberOfActiveLights);
        }

        private string parseThirdLine(TimeSpan time)
        {
            int elapsedHours = getElapsedHours(time);
            var numberOfActiveLights = elapsedHours % HoursEachUpperLightRepresent;
            return getHoursLightsString(numberOfActiveLights);
        }

        private string parseFourthLine(TimeSpan time)
        {
            var numberOfActiveLights = time.Minutes / MinutesEachUpperLightRepresent;
            return getMinutesUpperLightsString(numberOfActiveLights);
        }

        private string parseFifthLine(TimeSpan time)
        {
            var numberOfActiveLights = time.Minutes % MinutesEachUpperLightRepresent;
            return getMinutesLowerLightsString(numberOfActiveLights);
        }

        private int getElapsedHours(TimeSpan time)
        {
            return (int)Math.Floor(time.TotalHours);
        }

        private string getHoursLightsString(int numberOfActiveLights)
        {
            return getPaddingStringWithLightsOnOff(numberOfActiveLights, HoursAllLights);
        }

        private string getMinutesUpperLightsString(int numberOfActiveLights)
        {
            return getPaddingStringWithLightsOnOff(numberOfActiveLights, MinutesAllLights);
        }

        private string getMinutesLowerLightsString(int numberOfActiveLights)
        {
            return getPaddingStringWithLightsOnOff (numberOfActiveLights, MinutesModuluesAllLights);
        }

        private string getPaddingStringWithLightsOnOff(int numberOfActiveLights, string fullString)
        {
            var onLightsString = fullString.Substring(0, numberOfActiveLights);
            return onLightsString
                     .PadRight(fullString.Length, InactiveLight);
        }
    }
}
