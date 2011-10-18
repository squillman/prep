using System;
using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
    public class AscendingSort<ItemToSort, PropertyType> : IComparer<ItemToSort>
        where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToSort, PropertyType> accessor;

        public AscendingSort(Func<ItemToSort, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return accessor(x).CompareTo(accessor(y));
        }
    }
}