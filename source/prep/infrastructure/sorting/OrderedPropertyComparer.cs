using System;
using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
    public class OrderedPropertyComparer<ItemToSort, PropertyType> : IComparer<ItemToSort>
    {
        Func<ItemToSort, PropertyType> accessor;
        PropertyType[] propertyOrder;

        public OrderedPropertyComparer(Func<ItemToSort, PropertyType> accessor, params PropertyType[] order)
        {
            this.accessor = accessor;
            this.propertyOrder = order;
        }


        public int Compare(ItemToSort x, ItemToSort y)
        {
            return 0;    
            //return accessor(x).CompareTo(accessor(y));
        }

        public IComparer<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor )
        {
            return null;
        }
    }
}