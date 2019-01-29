using System.Threading.Tasks;
using NexPay.Data.Context;
using NexPay.Domain.Repositories;

namespace NexPay.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NexPayDbContext _context;

        public UnitOfWork(NexPayDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}