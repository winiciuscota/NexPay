using System;
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

        public async Task<TransactionPaginatedQueryResult> GetAllAsync(TransactionQuery queryVM) {
            var query = _dbContext.Set<Transaction>() as IQueryable<Transaction>;
            var result = new TransactionPaginatedQueryResult { TotalElements = await query.CountAsync() };

            if(queryVM.MinDate.HasValue) {
                query = query.Where(x => x.CreatedDate >= queryVM.MinDate);
            }
            if (queryVM.MaxDate.HasValue)
            {
                query = query.Where(x => x.CreatedDate >= queryVM.MaxDate);
            }
            if (!String.IsNullOrEmpty(queryVM.NameBeneficiary))
            {
                query = query.Where(x => x.Beneficiary.Name.Contains(queryVM.NameBeneficiary));
            }
            if (!String.IsNullOrEmpty(queryVM.NamePayer))
            {
                query = query.Where(x => x.Beneficiary.Name.Contains(queryVM.NamePayer));
            }

            result.TotalTransferredValue = await query.SumAsync(x => x.Value);
            query = query.ApplyPaging(queryVM.Page, queryVM.PageSize);

            result.Items = await query.ToListAsync();

            return result;
        }

    }
}