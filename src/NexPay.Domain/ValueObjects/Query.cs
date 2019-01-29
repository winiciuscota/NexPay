namespace NexPay.Domain.ValueObjects
{
    public class Query
    {
        /// <summary>
        /// Page index
        /// </summary>
        /// <value></value>
        public int Page { get; set; }

        /// <summary>
        /// Size of the page
        /// </summary>
        /// <value></value>
        public int PageSize { get; set; }
    }
}