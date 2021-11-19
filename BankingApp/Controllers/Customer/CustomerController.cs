using BankingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading.Tasks;

namespace BankingApp.Features.Customer
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        private readonly ICustomerServices _customerServices;
        public CustomerController(ILogger<CustomerController> logger, ICustomerServices customerServices)
        {
            _customerServices = customerServices;
            _logger = logger;

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerServices.GetById(id);

            if(customer is null)
            {
                _logger.LogError("Customer not found: {0}", id);

                return NotFound("Customer not found");
            }

            return Ok(customer);
        }
    }
}
