using System;
using System.Collections.Generic;

namespace f14
{
    /// <summary>
    /// Provides comparer which uses a specified <see cref="Comparison{T}"/> delegate to compare objects.
    /// </summary>
    /// <typeparam name="T">Type of objects to compare.</typeparam>
    public sealed class PredicateComparer<T> : IComparer<T>
    {
        private readonly Comparison<T> _comparison;

        /// <summary>
        /// Creates new instance of the comparer.
        /// </summary>
        /// <param name="comparison">The delegate to make the comparison.</param>
        public PredicateComparer(Comparison<T> comparison)
        {
            _comparison = comparison;
        }

        public int Compare(T x, T y) => _comparison(x, y);
    }
}
