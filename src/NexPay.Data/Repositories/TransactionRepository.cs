using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NexPay.Data.Context;
using NexPay.Data.Extensions;
using NexPay.Domain.Entities;
using NexPay.Domain.Repositories;
using NexPay.Domain.ValueObjects;

namespace NexPay.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(NexPayDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TransactionPaginatedQueryResult> GetAll(Query queryVM) {
            var query = _dbContext.Set<Transaction>() as IQueryable<Transaction>;
            var result = new TransactionPaginatedQueryResult { TotalElements = await query.CountAsync() };

            query = query.ApplyPaging(queryVM.Page, queryVM.PageSize);

            result.Items = await query.ToListAsync();
            result.TotalTransferredValue = await query.SumAsync(x => x.Value);

            return result;
        }

    }
}