using System;

namespace f14
{
    /// <summary>
    /// Provides helper methods to throw exceptions.
    /// </summary>
    public static class ExHelper
    {
        #region TryCatch

        /// <summary>
        /// Performs an action in the try-catch block.
        /// </summary>
        /// <param name="action">The action which will be invoked.</param>
        /// <param name="exHandler">Custom exception handler.</param>
        public static void Try(Action action, Action<Exception>? exHandler = default) => Try<Exception>(action, exHandler);

        /// <summary>
        /// Performs an action in the try-catch block.
        /// </summary>
        /// <typeparam name="T">Intercepted exception type.</typeparam>
        /// <param name="action">The action which will be invoked.</param>
        /// <param name="exHandler">Custom exception handler.</param>
        public static void Try<T>(Action action, Action<T>? exHandler) where T : Exception
        {
            try
            {
                action();
            }
            catch (T ex)
            {
                exHandler?.Invoke(ex);
            }
        }

        #endregion        
    }
}
