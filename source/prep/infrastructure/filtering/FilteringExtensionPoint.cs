using System;

namespace prep.infrastructure.filtering
{
    public class FilteringExtensionPoint<ItemToFilter, PropertyType> : IProvideAccessToFiltering<ItemToFilter,PropertyType>
    {
        public Func<ItemToFilter, PropertyType> accessor { get; private set; }

        public IProvideAccessToFiltering<ItemToFilter, PropertyType> not
        {
            get
            {
                return new NegatingFilteringExtensionPoint<ItemToFilter, PropertyType>(this);
            }
        }

        public FilteringExtensionPoint(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IMatchA<ItemToFilter> create_match_using(IMatchA<PropertyType> criteria)
        {
            return new PropertyMatch<ItemToFilter, PropertyType>(accessor, criteria);
        }
    }
}