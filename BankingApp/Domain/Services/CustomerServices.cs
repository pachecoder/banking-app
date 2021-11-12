using BankingApp.Domain;
using BankingApp.Repository;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Customer> GetById(int id)
        {
            return  _customerRepository.GetById(id);
        }
    }
}
