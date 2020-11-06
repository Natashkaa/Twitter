using System.Threading.Tasks;
using Twitter.Domain.Repositories;

namespace Twitter.RealizationAndContext.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TwitterDbContext context;
        public UnitOfWork(TwitterDbContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}