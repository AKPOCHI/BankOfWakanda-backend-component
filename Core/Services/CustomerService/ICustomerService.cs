

using Data.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace Core.Services.CustomerService
{
    public interface ICustomerService
    {
        string CreateCustomer(CreateCustomerDto createCustomerDto);
    }
}
