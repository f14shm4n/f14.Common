using System;
using System.Collections.Generic;

namespace f14
{
    /// <summary>
    /// Provides a pagination calculation methods.
    /// </summary>
    public static class PaginationUtil
    {
        /// <summary>
        /// Calculates pagination info.
        /// </summary>
        /// <param name="totalItems">Total number of elements.</param>
        /// <param name="itemsPerPage">Elements per page.</param>
        /// <param name="currentPageIndex">Current page index. Starts from 1.</param>
        /// <param name="indexesCount">The size of indexes list.</param>
        /// <returns>Creates new <see cref="PaginationInfo"/> object with calculated data.</returns>
        public static PaginationInfo Calculate(int totalItems, int itemsPerPage, int currentPageIndex, int indexesCount)
        {
            int prevPage = -1;
            int nextPage = -1;
            int middleIndex = (indexesCount + 1) / 2;
            int indexesPerSide = (indexesCount - 1) / 2;
            int pageCount = (int)Math.Ceiling((float)totalItems / itemsPerPage);

            // Ensures that we numerates indexes starts from 1, but not from 0
            if (currentPageIndex < 1)
            {
                currentPageIndex = 1;
            }
            // And checks if the current page index bigger than the max number of pages,
            // the page count also represent the highest page index.
            else if (currentPageIndex > pageCount)
            {
                currentPageIndex = pageCount;
            }

            SortedSet<int> indexes = new SortedSet<int>();
            // If current page index less or equals the middle index.
            // Then we return indexes from 1 to IndexesCount.
            if (currentPageIndex <= middleIndex)
            {
                indexesCount = Math.Min(indexesCount, pageCount);
                for (int i = 1; i <= indexesCount; i++)
                {
                    indexes.Add(i);
                }
            }
            else
            {
                int indexesFreeFromRight = Math.Max(currentPageIndex + indexesPerSide - pageCount, 0);
                int indexesToGetFromLeft = indexesPerSide + indexesFreeFromRight;

                if (indexesToGetFromLeft > currentPageIndex)
                {
                    indexesToGetFromLeft = currentPageIndex;
                }

                for (int i = indexesToGetFromLeft; i > 0; i--)
                {
                    if (i > currentPageIndex)
                    {
                        continue;
                    }

                    indexes.Add(currentPageIndex - i);
                }

                indexes.Add(currentPageIndex);

                for (int i = 1; i <= indexesPerSide - indexesFreeFromRight; i++)
                {
                    indexes.Add(currentPageIndex + i);
                }
            }

            if (indexes.Count == 0)
            {
                currentPageIndex = -1;
            }

            if (currentPageIndex > 1)
            {
                prevPage = currentPageIndex - 1;
            }

            if (currentPageIndex != -1 && currentPageIndex < pageCount)
            {
                nextPage = currentPageIndex + 1;
            }

            return new PaginationInfo(prevPage, nextPage, currentPageIndex, indexes);
        }
    }
}
