using BankingApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankingApp.Features.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerServices.GetById(id);

            if(customer is null)
            {
                return NotFound("Customer not found");
            }

            return Ok(customer);
        }
    }
}
