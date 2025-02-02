

using Data.Enum;

namespace Core.Services.AccountService
{
    public interface ICustomerAccountService
    {
        string CreateCustomerAccount(Guid customerId, AccountTypeEnum accountTypeEnum);
        string DepositFund(string accountNumber, decimal amt, Guid id);
    }
}
