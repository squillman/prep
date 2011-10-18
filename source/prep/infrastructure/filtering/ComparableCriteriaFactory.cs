using System;

namespace prep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : ICreateMatchers<ItemToFilter, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;
        ICreateMatchers<ItemToFilter, PropertyType> original;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> accessor,
                                         ICreateMatchers<ItemToFilter, PropertyType> original)
        {
            this.accessor = accessor;
            this.original = original;
        }

        public IMatchA<ItemToFilter> equal_to(PropertyType value)
        {
            return original.equal_to(value);
        }

        public IMatchA<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return original.equal_to_any(values);
        }

        public IMatchA<ItemToFilter> not_equal_to(PropertyType value)
        {
            return original.not_equal_to(value);
        }

        public IMatchA<ItemToFilter> greater_than(PropertyType value)
       {
           return original.create_match_using(x => compare_to_value(x, value) > 0);
       }

        public IMatchA<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return original.create_match_using(x => compare_to_value(x, start) >= 0 && compare_to_value(x, end) <= 0);
        }

        public IMatchA<ItemToFilter> create_match_using(Condition<ItemToFilter> condition)
        {
            return original.create_match_using(condition);
        }

        private int compare_to_value(ItemToFilter item,PropertyType value)
        {
            return accessor(item).CompareTo(value);
        }
    }
}