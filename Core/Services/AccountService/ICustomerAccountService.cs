

using Data.Enum;

namespace Core.Services.AccountService
{
    public interface ICustomerAccountService
    {
        string CreateCustomerAccount(Guid customerId, AccountTypeEnum accountTypeEnum);
        string DepositFund(string accountNumber, decimal amt, Guid id);
         string WithdrawFunds(string accountNumber, decimal amt);
        string TransferFunds(string senderaccountNumber, string receiveraccountNumber, decimal amt);
    }
}
