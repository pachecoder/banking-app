using BankingApp.Data;
using BankingApp.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingApp.Domain.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task Save(Transaction transaction)
        {


            //var account = _context.Accounts.Find(transaction.Account.Id);

            //var customer = _context.Customers.Find(transaction.Customer.Id);

            //transaction.Customer = customer;

            //transaction.Account = account;
            

            try
            {
                _context.Transactions.Add(transaction);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                var e = ex;
                throw;
            }
        }
    }
}
