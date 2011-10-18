using System;

namespace prep.infrastructure.filtering
{
    public class CriteriaFactory<ItemToFilter, PropertyType> : ICreateMatchers<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public CriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IMatchA<ItemToFilter> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public IMatchA<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return create_match_using(new EqualToAny<PropertyType>(values));
        }

        public IMatchA<ItemToFilter> not_equal_to(PropertyType value)
        {
            return equal_to(value).not();
        }

        public IMatchA<ItemToFilter> create_match_using(Condition<ItemToFilter> condition)
        {
            return new AnonymousMatch<ItemToFilter>(condition);
        }

        public IMatchA<ItemToFilter> create_match_using(IMatchA<PropertyType> criteria)
        {
            return new PropertyMatch<ItemToFilter, PropertyType>(accessor, criteria);
        }
    }
}