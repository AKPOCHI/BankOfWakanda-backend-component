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
       public string CreateCustomerAccount(Guid customerId, AccountTypeEnum accountTypeEnum)
        {
            return _obj.CreateCustomerAccount(customerId, accountTypeEnum);
            
        }

        [HttpPatch("Deposit-funds")]
        public string DepositFund(string accountNumber, decimal amt, Guid id)
        {
            return _obj.DepositFund(accountNumber,amt, id);
             
        }



    }
}
