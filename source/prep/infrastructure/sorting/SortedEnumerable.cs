using System;
using System.Collections;
using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
    public class SortedEnumerable<ItemToSort> : IEnumerable<ItemToSort>
    {
        IComparer<ItemToSort> comparer;
        IEnumerable<ItemToSort> items_to_sort;

        public SortedEnumerable(IEnumerable<ItemToSort> items, IComparer<ItemToSort> comparer)
        {
            this.items_to_sort = items;
            this.comparer = comparer;
        }

        public SortedEnumerable<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new SortedEnumerable<ItemToSort>(items_to_sort, comparer.then_by(Sort<ItemToSort>.by(accessor)));
        }

        public IEnumerator<ItemToSort> GetEnumerator()
        {
            return items_to_sort.sort_using(comparer).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}