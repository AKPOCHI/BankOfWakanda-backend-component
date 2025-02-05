using Core.Services.AccountService;
using Data.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CustomerAccountController
    {
        private readonly ICustomerAccountService _obj;

        public CustomerAccountController(ICustomerAccountService obj)
        {
            _obj = obj;
        }

        [HttpPost("create-Account")]
       public async Task <string> CreateCustomerAccount(Guid customerId, AccountTypeEnum accountTypeEnum)
        {
            return await _obj.CreateCustomerAccount(customerId, accountTypeEnum);
            
        }

        [HttpPatch("Deposit-funds")]
        public async Task <string> DepositFund(string accountNumber, decimal amt, Guid id)
        {
            return await _obj.DepositFund(accountNumber,amt, id);
             
        }

        [HttpPatch("Withdraw-Funds")]
        public async Task <string> WithdrawFunds(string accountNumber, decimal amt)
        {
            return await _obj.WithdrawFunds(accountNumber, amt);
        }

        [HttpPatch("Transfer-funds-between-acct")]
        public async Task <string> TransferFunds(string senderaccountNumber, string receiveraccountNumber, decimal amt)
        {
           return await _obj.TransferFunds(senderaccountNumber, receiveraccountNumber, amt);
        }


    }
}
