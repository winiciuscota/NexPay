using System.Collections;
using System.Collections.Generic;

namespace NexPay.Domain.Entities
{
    public class PaginatedQueryResult<TEntity>
    {

        public IEnumerable<TEntity> Items { get; set; }

        public int TotalElements { get; set; }

    }
}