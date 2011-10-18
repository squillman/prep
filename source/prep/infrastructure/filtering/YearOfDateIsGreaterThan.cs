using System;

namespace prep.infrastructure.filtering
{
    public class YearOfDateIsGreaterThan : IMatchA<DateTime>
    {
        int year;

        public YearOfDateIsGreaterThan(int year)
        {
            this.year = year;
        }

        public bool matches(DateTime item)
        {
            return item.Year > year;
        }
    }
}