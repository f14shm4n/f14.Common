using f14;

namespace System
{
    public static class Int32Extensions
    {
        /// <remarks>
        /// Do not use for cryptography.
        /// </remarks>
        public static int Rnd(this int min) => min.Rnd(int.MaxValue);

        /// <remarks>
        /// Do not use for cryptography.
        /// </remarks>
        public static int Rnd(this int min, int max) => RandomHelper.Next(min, max);

        public static IEnumerable<T> CreateEnumerable<T>(this int iterationCount, Func<int, int, T> factory)
        {
            ArgumentNullException.ThrowIfNull(factory);

            for (var i = 1; i <= iterationCount; i++)
            {
                yield return factory(i, iterationCount);
            }
        }

        public static IList<T> CreateList<T>(this int iterationCount, Func<int, int, T> factory)
        {
            return iterationCount.CreateEnumerable(factory).ToList();
        }
    }
}
