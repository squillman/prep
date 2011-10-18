using System;
using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
    public class DescendingSort<ItemToSort, PropertyType> : IComparer<ItemToSort>
        where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToSort, PropertyType> accessor;

        public DescendingSort(Func<ItemToSort, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return accessor(y).CompareTo(accessor(x));
        }
    }
}