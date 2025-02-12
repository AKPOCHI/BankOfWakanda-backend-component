using Core.Services.CustomerService;
using Data.Dtos;
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
        public string CreateCustomer([FromBody] CreateCustomerDto createCustomerDto)
        {

            return _obj.CreateCustomer(createCustomerDto);
          
        }

        [HttpPatch("update-customerPhonenumber")]
        public string UpdateCustomerPhoneNumber(Guid id, string phoneNumber)
        {
            return _obj.UpdateCustomerPhoneNumber(id, phoneNumber);
        }


    }
}
