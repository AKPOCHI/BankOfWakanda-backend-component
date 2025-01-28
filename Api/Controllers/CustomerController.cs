using Core.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _obj;

        public CustomerController(ICustomerService obj)
        {
            _obj = obj;
        }

        [HttpPost("Create-User")]
        public string CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string PassWORD)
        {
           
            _obj.CreateCustomer( firstName,  lastName, email,  phoneNumber,  PassWORD);
            return "New user added successfully";
        }


    }
}
