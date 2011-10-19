using System;
using System.Collections.Generic;
using prep.infrastructure.filtering;
using System.Linq;
using prep.infrastructure.sorting;

namespace prep.infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            return items.Where(x => true);
        }

        public static IEnumerable<ItemToMatch> all_items_matching<ItemToMatch>(this IEnumerable<ItemToMatch> items,
                                                                               IMatchA<ItemToMatch> criteria)
        {
            return items.Where(criteria.matches);
        }

        public static IEnumerable<ItemToSort> sort_using<ItemToSort>(this IEnumerable<ItemToSort> items,
                                                                     IComparer<ItemToSort> comparer)
        {
            var sorted = new List<ItemToSort>(items);
            sorted.Sort(comparer);
            return sorted;
        }


        public static IEnumerable<ItemToSort> order_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items, Func<ItemToSort,PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            var sorted = new List<ItemToSort>(items);
            sorted.Sort(new PropertyComparer<ItemToSort, PropertyType>(accessor, new ComparableComparer<PropertyType>()));
            return sorted;
        }

        public static IEnumerable<ItemToSort> order_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items, Func<ItemToSort, PropertyType> accessor, params PropertyType[] order)
        {
            var sorted = new List<ItemToSort>(items);
            sorted.Sort(new PropertyComparer<ItemToSort,PropertyType>(accessor,new FixedComparer<PropertyType>(order)));
            return sorted;
        }




        public static IEnumerable<ItemToSort> then_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items,
                                                                                Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            var sorted = new List<ItemToSort>(items);
            return sorted;
        } 
    }
}