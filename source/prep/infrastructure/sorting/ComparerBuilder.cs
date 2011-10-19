using System;
using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        IComparer<ItemToSort> initial;

        public ComparerBuilder(IComparer<ItemToSort> initial)
        {
            this.initial = initial;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return initial.Compare(x, y);
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor,
                                                           params PropertyType[] values)
        {
            return
                new ComparerBuilder<ItemToSort>(new CombinedComparer<ItemToSort>(initial,
                                                                                 Sort<ItemToSort>.by(accessor, values)));
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new CombinedComparer<ItemToSort>(initial,
                                                                                    Sort<ItemToSort>.by(accessor)));
        }

        public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new CombinedComparer<ItemToSort>(initial,
                                                                             Sort<ItemToSort>.by_descending(
                                                                                 accessor)));
        }
    }
}