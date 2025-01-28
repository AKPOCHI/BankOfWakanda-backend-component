using Data;
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

        public string CreateCustomer(string firstName,string lastName,string email,string phoneNumber,string PassWORD) 
        {

            var customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                PassWord = PassWORD,
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();


            return "Customer registered successfully";
        }

    }
}
