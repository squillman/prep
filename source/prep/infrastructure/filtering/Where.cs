using System;

namespace prep.infrastructure.filtering
{
    public class Where<ItemToFilter>
    {
        public static FilteringExtensionPoint<ItemToFilter,PropertyType> has_a<PropertyType>(Func<ItemToFilter, PropertyType> accessor) 
        {
            return new FilteringExtensionPoint<ItemToFilter, PropertyType>(accessor);
        }

        public static IMatchA<ItemToFilter> not
        {
            get
            {
            }
        } 
    }
}