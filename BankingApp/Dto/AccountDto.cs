namespace BankingApp.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }

        public virtual int AccountType { get; set; }

        public virtual decimal Balance { get; set; }
    }
}
