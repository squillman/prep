using System;

namespace prep.infrastructure.filtering
{
    public static class DateFilteringExtensions
    {
        public static IMatchA<ItemToFilter> greater_than<ItemToFilter>(
            this IProvideAccessToFiltering<ItemToFilter, DateTime> extension, int year)
        {
            return extension.create_match_using(new YearOfDateIsGreaterThan(year));
        }
    }
}