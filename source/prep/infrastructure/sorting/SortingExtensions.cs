using System;
using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
    public static class SortingExtensions
    {
        public static IComparer<ItemToSort> then_by<ItemToSort, PropertyType>(this IComparer<ItemToSort> comparer,
                                                                              Func<ItemToSort, PropertyType> accessor)
        {
        }
    }
}