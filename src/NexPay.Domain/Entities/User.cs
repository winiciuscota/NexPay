using System.Collections.Generic;

namespace NexPay.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public User()
        {
            Transactions = new List<Transaction>();
        }
    }
}