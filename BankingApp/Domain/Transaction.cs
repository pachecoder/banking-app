using BankingApp.Domain.Base;
using System;

namespace BankingApp.Domain
{
    public class Transaction : EntityBase
    {
        public Customer Customer { get; set; }

        public Account Account { get; set; }

        public int CustomerId { get; set; }

        public int AccountId { get; set; }

        public int TransactionType { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

    }
}
