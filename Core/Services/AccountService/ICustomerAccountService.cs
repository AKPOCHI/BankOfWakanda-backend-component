

using Data.Enum;

namespace Core.Services.AccountService
{
    public interface ICustomerAccountService
    {
         Task <string> CreateCustomerAccount(Guid customerId, AccountTypeEnum accountTypeEnum);
         Task <string> DepositFund(string accountNumber, decimal amt, Guid id);
          Task <string> WithdrawFunds(string accountNumber, decimal amt);
          Task <string> TransferFunds(string senderaccountNumber, string receiveraccountNumber, decimal amt);
    }
}
