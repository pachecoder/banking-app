using BankingApp.Domain;
using System;

namespace BankingApp.Dto
{
    public class TransactionDto
    {
        public int CustomerId { get; set; }

        public int AccountId { get; set; }

        public int TransactionType { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }
    }
}
