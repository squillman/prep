using System;
using prep.infrastructure.ranges;

namespace prep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : ICreateMatchers<ItemToFilter, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        ICreateMatchers<ItemToFilter, PropertyType> original;

        public ComparableCriteriaFactory(ICreateMatchers<ItemToFilter, PropertyType> original)
        {
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
            return create_match_using(new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value)));
        }

        public IMatchA<ItemToFilter> create_match_using(IMatchA<PropertyType> criteria)
        {
            return original.create_match_using(criteria);
        }

        public IMatchA<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return create_match_using(new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start, end)));
        }

        public IMatchA<ItemToFilter> create_match_using(Condition<ItemToFilter> condition)
        {
            return original.create_match_using(condition);
        }
    }
}