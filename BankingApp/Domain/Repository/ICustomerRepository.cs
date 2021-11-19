using BankingApp.Domain;
using BankingApp.Dto;
using System.Threading.Tasks;

namespace BankingApp.Repository
{
    public interface ICustomerRepository
    {
        public Task<CustomerDto> GetById(int id);
    }
}
