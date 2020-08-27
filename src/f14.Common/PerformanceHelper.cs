using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace f14
{
    /// <summary>
    /// Provides a simple mechanism for checking code performance.
    /// </summary>
    public static class PerformanceHelper
    {
        /// <summary>
        /// Performs the specified action and provides information about the time spent.
        /// </summary>
        /// <param name="action">The action for which performance evaluation will be performed.</param>
        /// <param name="callback">The callback function with performance info.</param>
        public static void Do(Action action, Action<TimeSpan> callback)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                action();
            }
            finally
            {
                sw.Stop();
            }

            callback(sw.Elapsed);
        }

        /// <summary>
        /// Performs the specified action asynchronously and provides information about the time spent.
        /// </summary>
        /// <param name="task">Async task.</param>
        /// <param name="callback">The callback function with performance info.</param>
        /// <returns>The performance helper task.</returns>
        public static async Task DoAsync(Func<Task> task, Action<TimeSpan> callback)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                await task().ConfigureAwait(false);
            }
            finally
            {
                sw.Stop();
            }

            callback(sw.Elapsed);
        }
    }
}
