using f14;

namespace System
{
    public static class DecimalExtensions
    {
        public static decimal Rnd(this decimal min) => min.Rnd(decimal.MaxValue);

        public static decimal Rnd(this decimal min, decimal max) => (decimal)RandomHelper.NextDouble() * (max - min) + min;
    }
}
