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
            _obj.CreateCustomerAccount(customerId, accountTypeEnum);
            return "Your account has been created successfully";
        }

        [HttpPatch("Deposit-funds")]
        public string DepositFund(string accountNumber, decimal amt, Guid id)
        {
            return _obj.DepositFund(accountNumber,amt, id);
             
        }



    }
}
