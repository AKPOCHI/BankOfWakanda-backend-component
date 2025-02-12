

using Core.Services.StatementOfAccount;
using Data;
using Data.Enum;
using Data.Models;
using Microsoft.Identity.Client;

namespace Core.Services.AccountService
{
    public class CustomerAccountService : ICustomerAccountService
    {
        private readonly AppDbContext _context;
        private readonly IStatementOfAccountService _statementOfAccountService;

        public CustomerAccountService(AppDbContext context, IStatementOfAccountService statementOfAccountService)
        {
            _context = context;
            _statementOfAccountService = statementOfAccountService;
        }

        public async Task <string> CreateCustomerAccount(Guid customerId, AccountTypeEnum accountTypeEnum)
        {
            try {
                var customerAccount = new CustomerAccount();
                // check to see that a customer has only one savings and currrent account
                var accTypeExist = _context.CustomerAccounts.FirstOrDefault(x => x.CustomerId == customerId && x.AccountType == accountTypeEnum);
                if (accTypeExist != null)
                {
                    return $"maximum number of {accountTypeEnum} has been reached";
                }

                customerAccount.AccountType = accountTypeEnum;
                customerAccount.CustomerId = customerId;
                customerAccount.AccountNumber = GenerateAccountNumber();
               
              await  _context.CustomerAccounts.AddAsync(customerAccount);
              await  _context.SaveChangesAsync();


                return $"here are your account details. " +
                    $"account number{customerAccount.AccountNumber}\n" +
                    $"account type :{customerAccount.AccountType}\n" +
                    $"account Id:{customerAccount.CustomerId}";

            }
            catch (Exception ex)
            {
                return $"an error occured{ex.Message}";
            }

        }



        private string GenerateAccountNumber()
        {
            Random random = new Random();
            var firstDigit = random.Next(2, 9).ToString();
            var remainingDigit = string.Empty;
            for (int i = 0; i <= 9; i++)
            {
                remainingDigit += random.Next(0, 10).ToString();
            }
            return firstDigit + remainingDigit;
        }


        public async Task <string> DepositFund(string accountNumber, decimal amt, Guid id, Guid customerId)
        {
            try {

                var acctExist = _context.CustomerAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber && x.Id == id && x.CustomerId == customerId);
                acctExist.AccountBallance += amt;

                _statementOfAccountService.SavetatementOfAccountService(acctExist.Id, customerId,DateTime.UtcNow.AddHours(1),"Deposit", amt,$"{DateTime.UtcNow.AddHours(1)} | ${amt} | {accountNumber}");


                await _context.SaveChangesAsync();
                return "successful deposit";
            }
            catch (OverflowException)
            {
                return "enter digit below 2 billion";
            }
            catch (Exception ex)
            {
                return $"an error occured pay close attention{ex.Message}";
            }

        }

        public async Task <string> WithdrawFunds(string accountNumber, decimal amt)
        {
            var acctExist = _context.CustomerAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
            acctExist.AccountBallance -= amt;
          await  _context.SaveChangesAsync();
            return $"{amt} has been withdrawn from your account";
        }

        public async Task <string> TransferFunds(string senderaccountNumber, string receiveraccountNumber, decimal amt)
        {
            try 
            { 
                var customerAccount = new CustomerAccount();
                var senderAcctExist = _context.CustomerAccounts.FirstOrDefault(x => x.AccountNumber == senderaccountNumber);
                var receiverAcctExist = _context.CustomerAccounts.FirstOrDefault(x => x.AccountNumber == receiveraccountNumber);

                if (senderAcctExist != null && receiverAcctExist != null && senderAcctExist.AccountBallance > amt)
                {
                    senderAcctExist.AccountBallance -= amt;
                    receiverAcctExist.AccountBallance += amt;
                   await _context.SaveChangesAsync() ;

                    return "Transfer completed successfully";
                }
                else if(senderAcctExist == null)
                {
                    return "Invalid Sender account";
                }
                else if (receiverAcctExist == null)
                {
                    return "Invalid receiver account";
                }
                else if(senderAcctExist.AccountBallance < amt)
                {
                    return "Insufficient fund";
                }
                else
                {
                    return "An error occurred";
                }
            }
            catch (Exception ex)
            {
                return $"an error occured{ex.Message}";
            }
             

        }
        
    }













 }

