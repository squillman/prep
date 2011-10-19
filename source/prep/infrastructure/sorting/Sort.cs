using System;
using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
    public class Sort<ItemToSort>
    {
        public static IComparer<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor,
                                                 params PropertyType[] order)
        {
            return new PropertyComparer<ItemToSort, PropertyType>(accessor, new FixedComparer<PropertyType>(order));
        }

        public static IComparer<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor,IApplyASortDirection direction = null)
            where PropertyType : IComparable<PropertyType>
        {
            direction = direction ?? SortDirections.ascending;

            return new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                  direction.apply_to(new ComparableComparer<PropertyType>()));
        }

    }
}