using BankingApp.Domain.Base;

namespace BankingApp.Domain
{
    public class Account : EntityBase
    {
        public virtual int AccountType { get; set; }

        public virtual decimal Balance { get; set; }

        public virtual Customer Customer { get; set; }

    }
}
