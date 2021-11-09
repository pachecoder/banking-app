using AutoMapper;
using MediatR;
using BankingApp.Data;
using BankingApp.Dto;
using BankingApp.Infrastructure.Exceptions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Features.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Domain.Customer> customerEntity = _context.Customers;

            if (customerEntity == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Customer with given ID is not found.");
            }

            var customer = await customerEntity
                    .FirstOrDefaultAsync(s => s.Id == request.CustomerId, cancellationToken);

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}