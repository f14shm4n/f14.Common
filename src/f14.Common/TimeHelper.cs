namespace f14
{
    /// <summary>
    /// Provides helper methods for working with time.
    /// </summary>
    public static class TimeHelper
    {
        /// <summary>
        /// Gets all timezone offsets that match the specified range 
        /// which is set by two params <paramref name="hourStart"/> and <paramref name="hourEnd"/>.
        /// </summary>
        /// <param name="hourStart">Sets the threshold of the timezone filter as minimum.</param>
        /// <param name="hourEnd">Sets the threshold of the timezone filter as maximum.</param>
        /// <returns>
        /// A collection of the <see cref="TimeSpan"/> that are represents the timezone offsets.
        /// </returns>
        public static ICollection<TimeSpan> GetTimeZoneOffsetsBetweenHours(int hourStart, int hourEnd)
        {
            // Here our results
            List<TimeSpan> results = [];
            // Selects all timezone offsets
            var timeZoneOffsets = TimeZoneInfo.GetSystemTimeZones().Select(x => x.BaseUtcOffset).Distinct().ToList();
            // Iterates the timezone offsets to find all of them that the date and time in a specified hourly range.
            foreach (var tzo in timeZoneOffsets)
            {
                // Calculates the date and time for particular timezone offset
                var tzNow = DateTimeOffset.UtcNow.ToOffset(tzo);
                // Checks if the current hours value from a particular timezone in our specified range
                if (tzNow.Hour >= hourStart && tzNow.Hour <= hourEnd)
                {
                    results.Add(tzo);
                }
            }

            return results;
        }

        /// <summary>
        /// Gets all timezones that match the specified range 
        /// which is set by two params <paramref name="hourStart"/> and <paramref name="hourEnd"/>.
        /// </summary>
        /// <param name="hourStart">Sets the threshold of the timezone filter as minimum.</param>
        /// <param name="hourEnd">Sets the threshold of the timezone filter as maximum.</param>
        /// <returns>
        /// A collection of the <see cref="TimeZoneInfo"/> that are represents the timezone offsets.
        /// </returns>
        public static ICollection<TimeZoneInfo> GetTimeZonesBetweenHours(int hourStart, int hourEnd)
        {
            // Here our results
            List<TimeZoneInfo> results = [];
            // Selects all timezone
            var timezones = TimeZoneInfo.GetSystemTimeZones();
            // Iterates the timezone offsets to find all of them that the date and time in a specified hourly range.
            foreach (var tz in timezones)
            {
                // Calculates the date and time for particular timezone offset
                var now = DateTimeOffset.UtcNow.ToOffset(tz.BaseUtcOffset);
                // Checks if the current hours value from a particular timezone in our specified range
                if (now.Hour >= hourStart && now.Hour <= hourEnd)
                {
                    results.Add(tz);
                }
            }

            return results;
        }
    }
}
