using System.Threading.Tasks;
namespace Twitter.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}