using System;
using System.Collections.Generic;

namespace BankingApp.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime BornDate { get; set; }

        public List<AccountDto> Account { get; set; }
    }
}