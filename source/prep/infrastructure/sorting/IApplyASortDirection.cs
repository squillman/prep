using System.Collections.Generic;

namespace prep.infrastructure.sorting
{
    public class SortDirections
    {
        public static IApplyASortDirection ascending = new RegularSort();
        public static IApplyASortDirection descending = new DescendingSort();
    }

    public class DescendingSort : IApplyASortDirection
    {
        public IComparer<T> apply_to<T>(IComparer<T> next_comparer)
        {
            return new ReverseComparer<T>(next_comparer);
        }
    }

    public class RegularSort : IApplyASortDirection
    {
        public IComparer<T> apply_to<T>(IComparer<T> next_comparer)
        {
            return next_comparer;
        }
    }

    public interface IApplyASortDirection
    {
        IComparer<T> apply_to<T>(IComparer<T> next_comparer);
    }
}