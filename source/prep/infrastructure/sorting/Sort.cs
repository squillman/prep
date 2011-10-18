using System;
using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
    public class Sort<ItemToSort>
    {
        public static IComparer<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
        {
            throw new NotImplementedException();
        }
    }
}