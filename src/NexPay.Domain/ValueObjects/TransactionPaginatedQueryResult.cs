using NexPay.Domain.Entities;

namespace NexPay.Domain.ValueObjects
{
    public class TransactionPaginatedQueryResult<T> : PaginatedQueryResult<Transaction>
    {
        public decimal TotalTransferredValue { get; set; }
    }

    public class TransactionPaginatedQueryResult : TransactionPaginatedQueryResult<Transaction>
    {
    }
} 