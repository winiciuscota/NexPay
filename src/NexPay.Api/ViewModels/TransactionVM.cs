using System;
using NexPay.Domain.ValueObjects;

namespace NexPay.Api.ViewModels
{
    public class TransactionVM
    {
        /// <summary>
        /// Id ot the transaction
        /// </summary>
        /// <value></value>
        public int Id { get; private set; }

        /// <summary>
        /// Id of the user
        /// </summary>
        /// <value></value>
        public int UserId { get; set; }

        /// <summary>
        /// Payer object
        /// </summary>
        /// <value></value>
        public Person Payer { get; set; }

        /// <summary>
        /// Beneficiary object
        /// </summary>
        /// <value></value>
        public Person Beneficiary { get; set; }

        /// <summary>
        /// Value of the transaction
        /// </summary>
        /// <value></value>
        public decimal Value { get; set; }

        /// <summary>
        /// Type of the transaction
        /// </summary>
        /// <value></value>
        public string TransactionType { get; set; }

    }
}