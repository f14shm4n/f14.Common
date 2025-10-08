using f14;

namespace System
{
    public static class DecimalExtensions
    {
        /// <remarks>
        /// Do not use for cryptography.
        /// </remarks>
        public static decimal Rnd(this decimal min) => min.Rnd(decimal.MaxValue);

        /// <remarks>
        /// Do not use for cryptography.
        /// </remarks>
        public static decimal Rnd(this decimal min, decimal max) => (decimal)RandomHelper.NextDouble() * (max - min) + min;
    }
}
