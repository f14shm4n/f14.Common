using f14;

namespace System
{
    public static class DoubleExtensions
    {
        public static double Rnd(this double min) => min.Rnd(double.MaxValue);

        public static double Rnd(this double min, double max) => RandomHelper.NextDouble() * (max - min) + min;
    }
}
