namespace prep.infrastructure.filtering
{
    public class NegatingFilteringExtensionPoint<ItemToFilter,PropertyType> : IProvideAccessToFiltering<ItemToFilter,PropertyType>
    {
        IProvideAccessToFiltering<ItemToFilter, PropertyType> original;

        public NegatingFilteringExtensionPoint(IProvideAccessToFiltering<ItemToFilter, PropertyType> original)
        {
            this.original = original;
        }

        public IMatchA<ItemToFilter> create_match_using(IMatchA<PropertyType> criteria)
        {
            return original.create_match_using(criteria).not();
        }
    }
}