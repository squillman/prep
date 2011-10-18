using System;

namespace prep.infrastructure.filtering
{
    public class FilteringExtensionPoint<ItemToFilter,PropertyType>
    {
        public Func<ItemToFilter, PropertyType> accessor { get; private set; }

        public FilteringExtensionPoint(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }
    }
}