using BankingApp.Domain.Base;
using System.Text.Json.Serialization;

namespace BankingApp.Domain
{
    public class Account : EntityBase
    {
        public virtual int AccountType { get; set; }

        public virtual decimal Balance { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }

    }
}
