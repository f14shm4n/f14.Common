namespace System.Collections.Generic
{
    /// <summary>
    /// Provides extesions methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Performs the specified action with an each item in the collection.
        /// </summary>
        /// <typeparam name="T">Type of the collection items.</typeparam>
        /// <param name="collection">Source collection.</param>
        /// <param name="action">Action to perform.</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            ArgumentNullException.ThrowIfNull(collection);
            ArgumentNullException.ThrowIfNull(action);

            foreach (T o in collection)
            {
                action(o);
            }
        }

        /// <summary>
        /// Finds the different elements of the collection using the passed predicate. See: 'https://stackoverflow.com/a/13231734/3207043'.
        /// </summary>
        /// <typeparam name="TSource">Source item type.</typeparam>
        /// <typeparam name="TKey">Key type for filtering.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="keySelector">Item selector.</param>
        /// <returns>Filtered collection.</returns>        
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(keySelector);

            var knownKeys = new HashSet<TKey>();
            return source.Where(element => knownKeys.Add(keySelector(element)));
        }
    }
}
