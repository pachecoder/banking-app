using MediatR;
using BankingApp.Dto;

namespace BankingApp.Features.Customer.Queries.GetCustomerById
{
    public record GetCustomerByIdQuery(int CustomerId) : IRequest<CustomerDto>;
}