using System;
using System.Collections.Generic;

namespace prep.infrastructure.filtering
{
    public class CriteriaFactory<ItemToFilter, PropertyType> : ICreateMatchers<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;
        private readonly MatchFactory<ItemToFilter> matchFactory;

        public CriteriaFactory(Func<ItemToFilter, PropertyType> accessor,MatchFactory<ItemToFilter> matchFactory )
        {
            this.accessor = accessor;
            this.matchFactory = matchFactory;
        }

        public IMatchA<ItemToFilter> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public IMatchA<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return create_match_using(x => new List<PropertyType>(values).Contains(accessor(x)));
        }

        public IMatchA<ItemToFilter> not_equal_to(PropertyType value)
        {
            return equal_to(value).not();
        }

        public IMatchA<ItemToFilter> create_match_using(Condition<ItemToFilter> condition)
        {
            return matchFactory.CreateUsing(condition);
        } 
    }
}