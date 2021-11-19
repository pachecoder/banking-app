using BankingApp.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingApp.Domain.Repository
{
    public interface ITransactionRepository
    {
        Task Save(Transaction transaction);
    }
}
