using System;
using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
    public class Sort<ItemToSort>
    {
        public static IComparer<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ReverseComparer<ItemToSort>(by(accessor));
        }

        public static IComparer<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor,
                                                             params PropertyType[] order)
        {
            return new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                  new FixedComparer<PropertyType>(order));
        }

        public static IComparer<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                  new ComparableComparer<PropertyType>());
        }
    }

}