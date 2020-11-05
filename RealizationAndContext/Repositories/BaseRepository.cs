namespace Twitter.RealizationAndContext.Repositories
{
    public class BaseRepository
    {
        protected readonly TwitterDbContext context;

        public BaseRepository(TwitterDbContext context) 
        {
            this.context = context;
        }
    }
}