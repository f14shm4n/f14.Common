using f14;

namespace System
{
    public static class Int32Extensions
    {
        public static int Rnd(this int min) => min.Rnd(int.MaxValue);

        public static int Rnd(this int min, int max) => RandomHelper.Next(min, max);

        public static IEnumerable<T> CreateEnumerable<T>(this int iterationCount, Func<int, int, T> factory)
        {
            for (var i = 1; i <= iterationCount; i++)
            {
                yield return factory(i, iterationCount);
            }
        }

        public static async IAsyncEnumerable<T> CreateEnumerableAsync<T>(this int iterationCount, Func<int, int, Task<T>> factory)
        {
            for (var i = 1; i <= iterationCount; i++)
            {
                yield return await factory(i, iterationCount).ConfigureAwait(false);
            }
        }

        public static List<T> CreateList<T>(this int iterationCount, Func<int, int, T> factory)
        {
            return iterationCount.CreateEnumerable(factory).ToList();
        }
    }
}
