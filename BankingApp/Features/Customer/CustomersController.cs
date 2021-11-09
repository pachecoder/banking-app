using BankingApp.Dto;
using BankingApp.Features.Customer.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace BankingApp.Features.Customer
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns an specific customer.
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <returns>Customer Details</returns>
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int customerId)
        {
            CustomerDto customer = await _mediator.Send(new GetCustomerByIdQuery(customerId));
            return Ok(customer);
        }
    }
}
