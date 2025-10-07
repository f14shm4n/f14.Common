namespace f14
{
    /// <summary>
    /// Provides math methods.
    /// </summary>
    public static class MathUtil
    {
        /// <summary>
        /// Clamps the value between min and max values.
        /// </summary>
        /// <param name="val">Value to clamp.</param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns>Returns min value if the value less than min, returns max value if the value greater than max, returns the value otherwise.</returns>
        public static byte Clamp(byte val, byte min, byte max) => (val < min) ? min : (val > max) ? max : val;

        /// <summary>
        /// Clamps the value between min and max values.
        /// </summary>
        /// <param name="val">Value to clamp.</param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns>Returns min value if the value less than min, returns max value if the value greater than max, returns the value otherwise.</returns>
        public static int Clamp(int val, int min, int max) => (val < min) ? min : (val > max) ? max : val;

        /// <summary>
        /// Clamps the value between min and max values.
        /// </summary>
        /// <param name="val">Value to clamp.</param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns>Returns min value if the value less than min, returns max value if the value greater than max, returns the value otherwise.</returns>
        public static double Clamp(double val, double min, double max) => (val < min) ? min : (val > max) ? max : val;

        /// <summary>
        /// Clamps the value between min and max values.
        /// </summary>
        /// <param name="val">Value to clamp.</param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns>Returns min value if the value less than min, returns max value if the value greater than max, returns the value otherwise.</returns>
        public static TimeSpan Clamp(TimeSpan val, TimeSpan min, TimeSpan max) => (val < min) ? min : (val > max) ? max : val;

        /// <summary>
        /// Clamps the value between min and max values.
        /// </summary>
        /// <param name="val">Value to clamp.</param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns>Returns min value if the value less than min, returns max value if the value greater than max, returns the value otherwise.</returns>
        public static DateTime Clamp(DateTime val, DateTime min, DateTime max) => (val < min) ? min : (val > max) ? max : val;

        /// <summary>
        /// Determines whether the given value is between left and right limits.
        /// </summary>
        /// <param name="val">Value to check.</param>
        /// <param name="left">Left limit.</param>
        /// <param name="right">Right limit.</param>
        /// <returns>True - if value is between left and right limits; False - otherwise.</returns>
        public static bool Include(double val, double left, double right) => left <= val && val <= right;

        /// <summary>
        /// Returns the percent for the given values.
        /// </summary>
        /// <param name="current">Current value.</param>
        /// <param name="total">The value which equals to 100%.</param>
        /// <returns>The percent value.</returns>
        public static double Percent(double current, double total) => Part(current, total) * 100;

        /// <summary>
        /// Return the part of total. Just divides the current value on the total value.
        /// </summary>
        /// <param name="current">Current value.</param>
        /// <param name="total">Total value of anything.</param>
        /// <returns>Part of the total.</returns>
        public static double Part(double current, double total) => current / total;

        /// <summary>
        /// Compares two objects and returns the larger one.
        /// </summary>
        /// <param name="x">First object.</param>
        /// <param name="y">Second object.</param>
        /// <returns>Larger object.</returns>
        public static TimeSpan Max(TimeSpan x, TimeSpan y) => x > y ? x : y;

        /// <summary>
        /// Compares two objects and returns the larger one.
        /// </summary>
        /// <param name="x">First object.</param>
        /// <param name="y">Second object.</param>
        /// <returns>Larger object.</returns>
        public static DateTime Max(DateTime x, DateTime y) => x > y ? x : y;

        /// <summary>
        /// Compares two objects and returns the larger one.
        /// </summary>
        /// <param name="x">First object.</param>
        /// <param name="y">Second object.</param>
        /// <returns>Larger object.</returns>
        public static DateTimeOffset Max(DateTimeOffset x, DateTimeOffset y) => x > y ? x : y;

        /// <summary>
        /// Compares two objects with using <see cref="Comparer{T}.Default"/> and returns the larger object.
        /// </summary>
        /// <typeparam name="T">Type of objects that are will be compared.</typeparam>
        /// <param name="x">First object.</param>
        /// <param name="y">Second object.</param>
        /// <returns>Larger object.</returns>
        public static T Max<T>(T x, T y)
        {            
            if (Comparer<T>.Default.Compare(x, y) > 0)
            {
                return x;
            }
            return y;
        }
    }
}
