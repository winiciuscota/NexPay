using System.Threading.Tasks;
using NexPay.Domain.Entities;
using NexPay.Domain.ValueObjects;

namespace NexPay.Domain.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<TransactionPaginatedQueryResult> GetAllAsync(TransactionQuery queryVM);
    }
}