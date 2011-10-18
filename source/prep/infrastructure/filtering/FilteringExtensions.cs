using System;
using prep.infrastructure.ranges;

namespace prep.infrastructure.filtering
{
    public static class FilteringExtensions
    {
        public static IMatchA<ItemToFilter> equal_to<ItemToFilter,PropertyType>(this FilteringExtensionPoint<ItemToFilter,PropertyType> extension,PropertyType value)
        {
            return equal_to_any(extension,value);
        }

        public static IMatchA<ItemToFilter> equal_to_any<ItemToFilter,PropertyType>(this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,params PropertyType[] values)
        {
            return extension_point.create_match_using(new EqualToAny<PropertyType>(values));
        }

        public static IMatchA<ItemToFilter> not_equal_to<ItemToFilter,PropertyType>(this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,PropertyType value)
        {
            return equal_to_any(extension_point, value).not();
        }

        public static IMatchA<ItemToFilter> greater_than<ItemToFilter,PropertyType>(this FilteringExtensionPoint<ItemToFilter,PropertyType> extension,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return create_match_using(extension, new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value)));
        }

        public static IMatchA<ItemToFilter> create_match_using<ItemToFilter,PropertyType>(this FilteringExtensionPoint<ItemToFilter,PropertyType> extension,IMatchA<PropertyType> criteria)
        {
            return new PropertyMatch<ItemToFilter, PropertyType>(extension.accessor, criteria);
        }

        public static IMatchA<ItemToFilter> between<ItemToFilter,PropertyType>(this FilteringExtensionPoint<ItemToFilter,PropertyType> extension,PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return create_match_using(extension, new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start, end)));
        }

    }
}