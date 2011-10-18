namespace prep.infrastructure.filtering
{
    public interface IProvideAccessToFiltering<ItemToFilter,PropertyType>
    {
        IMatchA<ItemToFilter> create_match_using(IMatchA<PropertyType> criteria);
    }
}