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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(NexPayDbContext dbContext) : base(dbContext)
        {
        }

    }
}