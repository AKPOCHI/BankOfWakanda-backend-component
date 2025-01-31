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
           
            _obj.CreateCustomer(createCustomerDto);
            return "New user added successfully";
        }


    }
}
