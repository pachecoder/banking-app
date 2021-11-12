using BankingApp.Domain;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public interface ICustomerServices
    {
        public Task<Customer> GetById(int id);
    }
}
