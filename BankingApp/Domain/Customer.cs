using BankingApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankingApp.Domain
{
    public class Customer : EntityBase
    {
        [Required]
        public string FullName { get; set; }

        public DateTime BornDate { get; set; }

        public bool IsFlagged { get; set; }

        [Required]
        public string Ssn { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}