using BankingApp.Domain;
using System.Threading.Tasks;

namespace BankingApp.Repository
{
    public interface ICustomerRepository
    {
        public Task<Customer> GetById(int id);
    }
}
