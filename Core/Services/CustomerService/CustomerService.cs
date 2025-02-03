using Data;
using Data.Dtos;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public string CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            try { 
            var customer = new Customer()
            {
                FirstName = createCustomerDto.FirstName,
                LastName = createCustomerDto.LastName,
                Email = createCustomerDto.Email,
                PhoneNumber = createCustomerDto.PhoneNumber,
                PassWord = createCustomerDto.PassWord,
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();


            return "Customer registered successfully";
            }
            catch (Exception ex)
            {
                return $"an error occured{ex.Message}";
            }
        }

    }
}
