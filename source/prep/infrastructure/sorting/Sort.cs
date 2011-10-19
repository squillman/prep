using System;

namespace prep.infrastructure.sorting
{
    public class Sort<ItemToSort>
    {
        public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new ReverseComparer<ItemToSort>(by(accessor)));
        }







        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor,
                                                 params PropertyType[] order)
        {
            return new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor, new FixedComparer<PropertyType>(order)));
        }






        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                  new ComparableComparer<PropertyType>()));
        }
    }
}