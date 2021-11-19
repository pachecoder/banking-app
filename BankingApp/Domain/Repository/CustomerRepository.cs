using BankingApp.Data;
using BankingApp.Domain;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Threading.Tasks;

namespace BankingApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task<Customer> GetById(int id)
        {

            try
            {
                if (id == 2)
                    throw new NotImplementedException();

                var customer = _context.Customers.Include(s => s.Account);

                return await customer.FirstOrDefaultAsync(s => s.Id == id);

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
