using System;
using prep.infrastructure.ranges;

namespace prep.infrastructure.filtering
{
    public static class FilteringExtensions
    {
        public static IMatchA<ItemToFilter> equal_to<ItemToFilter,PropertyType>(this IProvideAccessToFiltering<ItemToFilter,PropertyType> extension,PropertyType value)
        {
            return equal_to_any(extension,value);
        }

        public static IMatchA<ItemToFilter> equal_to_any<ItemToFilter,PropertyType>(this IProvideAccessToFiltering<ItemToFilter,PropertyType> extension_point,params PropertyType[] values)
        {
            return extension_point.create_match_using(new EqualToAny<PropertyType>(values));
        }

        public static IMatchA<ItemToFilter> greater_than<ItemToFilter,PropertyType>(this IProvideAccessToFiltering<ItemToFilter,PropertyType> extension,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return extension.create_match_using(new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value)));
        }

        public static IMatchA<ItemToFilter> between<ItemToFilter,PropertyType>(this IProvideAccessToFiltering<ItemToFilter,PropertyType> extension,PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return extension.create_match_using(new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start, end)));
        }

    }

    public static class DateFilteringExtensions
    {
        public static IMatchA<ItemToFilter> greater_than<ItemToFilter>(this IProvideAccessToFiltering<ItemToFilter, DateTime> extension, int value)
        {
            return
                extension.create_match_using(
                    new FallsInRange<DateTime>(new RangeWithNoUpperBound<DateTime>(value)));
        } 
    }
}