using System.Threading.Tasks;

namespace BankingApp.Domain.Repository
{
    public class TransactionServices : ITransactionServices
    {
        private readonly ITransactionRepository repository;

        public TransactionServices(ITransactionRepository repository)
        {
            this.repository = repository;
        }

        public async Task Save(Transaction transaction)
        {
            await this.repository.Save(transaction);
        }
    }
}
