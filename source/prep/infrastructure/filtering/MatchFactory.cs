namespace prep.infrastructure.filtering
{
    public class MatchFactory<ItemToMatch>
    {
        public MatchFactory()
        {
            
        }

        public IMatchA<ItemToMatch> CreateUsing(Condition<ItemToMatch> condition)
        {
            return new AnonymousMatch<ItemToMatch>(condition);
        }
    }
}