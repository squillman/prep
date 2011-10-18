using System;
using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
    public class Sort<ItemToSort>
    {
        public static IComparer<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new DescendingSort<ItemToSort, PropertyType>(accessor);
        }

        public static IComparer<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            throw new NotImplementedException();
        }
    }
}