namespace prep.infrastructure.filtering
{
    public interface ICreateMatchers<ItemToFilter, PropertyType>
    {
        IMatchA<ItemToFilter> equal_to(PropertyType value);
        IMatchA<ItemToFilter> equal_to_any(params PropertyType[] values);
        IMatchA<ItemToFilter> not_equal_to(PropertyType value);
        IMatchA<ItemToFilter> create_match_using(Condition<ItemToFilter> condition);
    }
}