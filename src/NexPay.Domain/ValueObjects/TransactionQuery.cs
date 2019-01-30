using System;
namespace NexPay.Domain.ValueObjects
{
    public class TransactionQuery : Query
    {
        /// <summary>
        /// Minimun date of the transaction
        /// </summary>
        /// <value></value>
        public DateTime? MinDate { get; set; }

        /// <summary>
        /// Maximun date of the transaction
        /// </summary>
        /// <value></value>
        public DateTime? MaxDate { get; set; }

        /// <summary>
        /// Name of the beneficiary of the transaction
        /// </summary>
        /// <value></value>
        public string NameBeneficiary { get; set; }

        /// <summary>
        /// Name of the payer of the transaction
        /// </summary>
        /// <value></value>
        public string NamePayer { get; set; }
    }
}