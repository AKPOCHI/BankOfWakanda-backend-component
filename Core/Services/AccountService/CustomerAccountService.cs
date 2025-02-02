

using Data;
using Data.Enum;
using Data.Models;

namespace Core.Services.AccountService
{
    public class CustomerAccountService : ICustomerAccountService
    {
        private readonly AppDbContext _context;
public CustomerAccountService(AppDbContext context)
        {
            _context = context;
        }

        public string CreateCustomerAccount(Guid customerId, AccountTypeEnum accountTypeEnum)
        {

            var customerAccount = new CustomerAccount();
            // check to see that a customer has only one savings and current account
            var savingsAccountCheck = _context.CustomerAccounts.Where(x => x.Id == customerId && customerAccount.AccountType == AccountTypeEnum.savings);
            if(savingsAccountCheck != null)
            {
                return "maximum number of savings account reached you cant have more than one savings account";
            }
            // check to see that a customer has only one current account
            var currentAccountCheck = _context.CustomerAccounts.Where(x => x.Id == customerId && customerAccount.AccountType==AccountTypeEnum.current);
            if(currentAccountCheck != null)
            {
                return "maximum number of current account reached you cant have more than one current account";
            }




            // var accountTypeEnum = new AccountTypeEnum();

            customerAccount.AccountType = accountTypeEnum;
            customerAccount.CustomerId = customerId;
            customerAccount.AccountNumber = GenerateAccountNumber();

            _context.CustomerAccounts.Add(customerAccount);
            _context.SaveChanges();


            return $"here are your account details. " +
                $"account number{customerAccount.AccountNumber}\n" +
                $"account type :{customerAccount.AccountType}\n" +
                $"account Id:{customerAccount.CustomerId}";



        }

        

        private string GenerateAccountNumber()
        {
            Random random = new Random();
            var firstDigit = random.Next(2, 9).ToString();
            var remainingDigit = string.Empty;
            for(int i= 0; i<=9; i++)
            {
                remainingDigit += random.Next(0, 10).ToString();
            }
            return firstDigit + remainingDigit; 
        }


        public string DepositFund(string accountNumber, decimal amt,Guid id)
        {
            var acctExist = _context.CustomerAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber && x.Id == id );
            acctExist.AccountBallance += amt;
            _context.SaveChanges();
            return "successful deposit";

        }



    }
}
