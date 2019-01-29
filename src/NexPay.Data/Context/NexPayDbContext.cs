using Microsoft.EntityFrameworkCore;
using NexPay.Data.Configuration;
using NexPay.Domain.Entities;

namespace NexPay.Data.Context
{
    public class NexPayDbContext : DbContext
    {
        public NexPayDbContext(DbContextOptions<NexPayDbContext> options)
         : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            base.OnModelCreating(modelBuilder);

        }
    }
}