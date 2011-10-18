using System;

namespace prep.infrastructure.filtering
{
    public class IsGreaterThan<T> : IMatchA<T> where T : IComparable<T>
    {
        T start;

        public IsGreaterThan(T start)
        {
            this.start = start;
        }

        public bool matches(T item)
        {
            return item.CompareTo(start) > 0;
        }
    }
}