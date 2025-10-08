using f14;

namespace System
{
    public static class DoubleExtensions
    {
        /// <remarks>
        /// Do not use for cryptography.
        /// </remarks>
        public static double Rnd(this double min) => min.Rnd(double.MaxValue);

        /// <remarks>
        /// Do not use for cryptography.
        /// </remarks>
        public static double Rnd(this double min, double max) => RandomHelper.NextDouble() * (max - min) + min;
    }
}
