using f14;

namespace System
{
    public static class FloatExtensions
    {
        /// <remarks>
        /// Do not use for cryptography.
        /// </remarks>
        public static float Rnd(this float min) => min.Rnd(float.MaxValue);

        /// <remarks>
        /// Do not use for cryptography.
        /// </remarks>
        public static float Rnd(this float min, float max) => (float)RandomHelper.NextDouble() * (max - min) + min;
    }
}
