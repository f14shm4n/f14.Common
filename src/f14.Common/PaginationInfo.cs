namespace f14
{
    /// <summary>
    /// The pagination info instance.
    /// </summary>
    public sealed class PaginationInfo
    {
        public PaginationInfo(int previous, int next, int current, IReadOnlyCollection<int> indexes)
        {
            Previous = previous;
            Next = next;
            Current = current;
            Indexes = indexes;
        }

        /// <summary>
        /// Gets or sets the previouse page index.
        /// </summary>
        public int Previous { get; }

        /// <summary>
        /// Gets or sets the next page index.
        /// </summary>
        public int Next { get; }

        /// <summary>
        /// Gets or sets the current page index.
        /// </summary>
        public int Current { get; }

        /// <summary>
        /// Gets or sets the collection of page indexes.
        /// </summary>
        public IReadOnlyCollection<int> Indexes { get; }

        ///<inheritdoc/>
        public override string ToString()
        {
            return $"{nameof(Previous)}: {Previous}; {nameof(Current)}: {Current}; {nameof(Next)}: {Next}; {nameof(Indexes)}: {Indexes.Count}";
        }
    }
}
