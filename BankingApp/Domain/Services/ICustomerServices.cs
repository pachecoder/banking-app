using BankingApp.Dto;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public interface ICustomerServices
    {
        public Task<CustomerDto> GetById(int id);
    }
}
