

namespace Core.Services.CustomerService
{
    public interface ICustomerService
    {
        string CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string PassWORD);
    }
}
