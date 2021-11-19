using BankingApp.Domain.Base;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BankingApp.Domain
{
    public class Account : EntityBase
    {
        public Account()
        {
            Transaction = new HashSet<Transaction>();
        }

        public virtual int AccountType { get; set; }

        public virtual decimal Balance { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }

    }
}
