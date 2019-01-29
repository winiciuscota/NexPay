using System.Threading.Tasks;

namespace NexPay.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}