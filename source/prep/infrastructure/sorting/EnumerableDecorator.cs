using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.infrastructure.sorting
{

    public class EnumerableDecorator<ItemToSort> : IEnumerable<ItemToSort>
    {
        private ComparerBuilder<ItemToSort> builder;
        private List<ItemToSort> itemsToSort;

        public EnumerableDecorator(List<ItemToSort> items, ComparerBuilder<ItemToSort> builder)
        {
            this.itemsToSort = items;
            this.builder = builder;
        }
    
        public EnumerableDecorator<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            var comparer = builder.then_by(accessor);
            itemsToSort.Sort(comparer);
            return this;
        }

        public IEnumerator<ItemToSort> GetEnumerator()
        {
            return itemsToSort.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}