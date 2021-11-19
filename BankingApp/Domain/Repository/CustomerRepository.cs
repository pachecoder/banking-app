using AutoMapper;
using BankingApp.Data;
using BankingApp.Domain;
using BankingApp.Dto;
using BankingApp.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BankingApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    
        public async Task<CustomerDto> GetById(int id)
        {

            try
            {
                IQueryable<Domain.Customer> customerEntity = _context.Customers.Include(s => s.Account);

                if (customerEntity == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Customer with given ID is not found.");
                }

                var customer = await customerEntity
                                .AsNoTracking() //Permite ejecutar mas rapido una consulta,
                                                //al no validar si se modifico en memoria la entidad.
                                .FirstOrDefaultAsync(s => s.Id == id);

                return _mapper.Map<CustomerDto>(customer);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
