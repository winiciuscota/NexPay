using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NexPay.Data.Extensions;
using NexPay.Domain.Entities;
using NexPay.Domain.Repositories;
using NexPay.Domain.ValueObjects;

namespace NexPay.Data.Repositories
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly DbContext _dbContext;
        protected readonly Dictionary<string, Expression<Func<TEntity, object>>> _columnsMap;


        public Repository(DbContext context)
        {
            _dbContext = context;
            _columnsMap = new Dictionary<string, Expression<Func<TEntity, object>>>();
        }

        public Repository(DbContext context, Dictionary<string, Expression<Func<TEntity, object>>> columnsMap)
        {
            _dbContext = context;
            _columnsMap = columnsMap;
        }

        public void Save(TEntity o) => _dbContext.Add(o);
        public void Save(IEnumerable<TEntity> objs) => _dbContext.AddRange(objs);
        public async Task<List<TEntity>> GetAllAsync() => await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<PaginatedQueryResult<TEntity>> GetAllAsync(Query queryVM)
        {
            var query = _dbContext.Set<TEntity>() as IQueryable<TEntity>;
            var result = new PaginatedQueryResult<TEntity> { TotalElements = await query.CountAsync() };

            query = query.ApplyPaging(queryVM.Page, queryVM.PageSize);

            result.Items = await query.ToListAsync();

            return result;
        }
    }
}