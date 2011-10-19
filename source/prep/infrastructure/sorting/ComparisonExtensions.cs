using System;
using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
    public static class ComparisonExtensions
    {
        public static IComparer<ItemToSort> then_by<ItemToSort>(this IComparer<ItemToSort> first,
                                                                IComparer<ItemToSort> second)
        {
            return new CombinedComparer<ItemToSort>(first, second);
        }

        public static IComparer<ItemToSort> then_by<ItemToSort, PropertyType>(this IComparer<ItemToSort> first,
                                                                              Func<ItemToSort, PropertyType> accessor,
                                                                              params PropertyType[] order)
        {
            return new CombinedComparer<ItemToSort>(first, Sort<ItemToSort>.by(accessor, order));
        }

        public static IComparer<ItemToSort> then_by<ItemToSort, PropertyType>(this IComparer<ItemToSort> first,
                                                                              Func<ItemToSort, PropertyType> accessor,
                                                                              IApplyASortDirection direction)
            where PropertyType : IComparable<PropertyType>
        {
            var next_comparer = Sort<ItemToSort>.by(accessor);
            next_comparer = direction.apply_to(next_comparer);
            return new CombinedComparer<ItemToSort>(first, next_comparer);
        }

        public static IComparer<ItemToSort> then_by<ItemToSort, PropertyType>(this IComparer<ItemToSort> first,
                                                                              Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return first.then_by(accessor, SortDirections.ascending);
        }

        public static SortedEnumerable<ItemToSort> order_by<ItemToSort, PropertyType>(
            this IEnumerable<ItemToSort> items,
            Func<ItemToSort, PropertyType> accessor, params PropertyType[] order)
        {
            return new SortedEnumerable<ItemToSort>(new List<ItemToSort>(items), Sort<ItemToSort>.by(accessor, order));
        }
    }
}