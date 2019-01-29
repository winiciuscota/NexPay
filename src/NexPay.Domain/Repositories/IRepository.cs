using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NexPay.Domain.Entities;
using NexPay.Domain.ValueObjects;

namespace NexPay.Domain.Repositories
{
    /// <summary>
    /// Base repository interface
    /// </summary>
    /// <typeparam name="TEntity">type of the repository's entity</typeparam>
    public interface IRepository<TEntity>
    {

        /// <summary>
        /// saves the object
        /// </summary>
        /// <param name="o">object</param>
        void Save(TEntity o);

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="objs">list of objects</param>
        void Save(IEnumerable<TEntity> objs);

        /// <summary>
        /// Get all objects
        /// </summary>
        /// <param name="o"></param>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Get single entity by id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns>Id of the entity to be returned</returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// GEt all elements according to the query object
        /// </summary>
        /// <param name="query">The query object</param>
        /// <returns></returns>
        Task<PaginatedQueryResult<TEntity>> GetAllAsync(Query query);
    }
}