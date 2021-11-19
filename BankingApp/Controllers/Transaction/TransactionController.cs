using AutoMapper;
using BankingApp.Domain.Repository;
using BankingApp.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading.Tasks;

namespace BankingApp.Controllers.Transaction
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;

        private readonly ITransactionServices services;
        private readonly IMapper _mapper;


        public TransactionController(ILogger<TransactionController> logger, ITransactionServices services, IMapper mapper)
        {
            this.services = services;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost("Buy")]
        public async Task<IActionResult> Buy([FromBody] TransactionDto transactionDto)
        {
            _logger.LogInformation("{@TransactionDto}", transactionDto);

            var transaction = _mapper.Map<Domain.Transaction>(transactionDto);

            await this.services.Save(transaction);

            return Ok();
        }
    }
}
