
using Data;
using Data.Models;

namespace Core.Services.StatementOfAccount
{
    public class StatementOfAccountService : IStatementOfAccountService
    {
        private readonly AppDbContext _context;

        public StatementOfAccountService(AppDbContext context)
        {
            _context = context;
        }

        public string SavetatementOfAccountService(Guid accountId,Guid customerId,DateTime dateOfTransaction,string typeOfTransaction,decimal amount,string description)
        {
            var statementOfAccount = new Data.Models.StatementOfAccount()
            {
                AccountId = accountId,
                CustomerId = customerId,
                DateOfTransaction = dateOfTransaction,
                TypeOfTransaction = typeOfTransaction,
                Amount = amount,    
                Description = description   
            };
            _context.StatementOfAccounts.Add(statementOfAccount);
            _context.SaveChanges();


            return "statement of account updated successfully";
        }

        internal void SavetatementOfAccountService(string v)
        {
            throw new NotImplementedException();
        }
    }
}
