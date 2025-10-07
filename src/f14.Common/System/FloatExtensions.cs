using f14;

namespace System
{
    public static class FloatExtensions
    {
        public static float Rnd(this float min) => min.Rnd(float.MaxValue);

        public static float Rnd(this float min, float max) => (float)RandomHelper.NextDouble() * (max - min) + min;
    }
}
