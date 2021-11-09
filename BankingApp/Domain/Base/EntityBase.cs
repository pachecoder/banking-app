using System;

namespace BankingApp.Domain.Base
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}
