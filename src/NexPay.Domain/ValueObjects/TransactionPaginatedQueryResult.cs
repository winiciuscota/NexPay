using NexPay.Domain.Entities;

namespace NexPay.Domain.ValueObjects
{
    public class TransactionPaginatedQueryResult : PaginatedQueryResult<Transaction>
    {
        public decimal TotalTransferredValue { get; set; }
    }
}