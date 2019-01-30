using System;
using NexPay.Domain.Constants;
using NexPay.Domain.ValueObjects;

namespace NexPay.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; private set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public Person Payer { get; set; }

        public Person Beneficiary { get; set;  }

        public decimal Value { get; set; }
        public string TransactionType { get; private set; }

        public bool Deleted { get; private set; }

        public DateTime CreatedDate { get; set; }

        public void SetTransactionType() {
            if(Payer.Bank == Beneficiary.Bank) {
                TransactionType = TransactionTypes.Cc;
            }
            else if(DateTime.Now.Hour > 10 && DateTime.Now.Hour < 18 && Value <= 5000) {
                TransactionType = TransactionTypes.Ted;
            }
            else {
                TransactionType = TransactionTypes.Doc;
            }
        }

        public void Delete() {
            Deleted = true;
        }

        public Transaction()
        {
            CreatedDate = DateTime.Now;
        }
    }
}