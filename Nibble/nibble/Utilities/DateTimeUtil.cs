using System;
namespace nibble.Utilities
{
    public class DateTimeUtil
    {
        public static string UnixTimestampToDateTimeString(string unixTimestamp)
        {

            long unixDate;
            DateTime start;
            DateTime date;

            unixDate = long.Parse(unixTimestamp);
            start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            date = start.AddMilliseconds(unixDate).ToLocalTime();

            return date.ToString("MM-dd-yyyy");

        }

        public static long DateTimeStringToUnixTimestamp(DateTime dateTime)
        {
            return (long)(dateTime - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))).TotalMilliseconds;
        }
    }
}
