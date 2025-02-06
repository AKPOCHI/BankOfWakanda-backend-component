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

                // Validate first name before proceeding
                if (!ValidateName(createCustomerDto.FirstName))
                {
                    return $"Invalid  {createCustomerDto.FirstName}. It should not start with a digit or letters A, B, or C.";
                }
                if (!ValidateName(createCustomerDto.LastName))
                {
                    return $"Invalid  {createCustomerDto.LastName}. It should not start with a digit or letters A, B, or C.";
                }

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
      
        public string UpdateCustomerPhoneNumber(Guid id, string phoneNumber)
        {
            var customerExist = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customerExist != null)
            {
                customerExist.PhoneNumber = phoneNumber;
                _context.SaveChanges();
            }
            else
            {
                return "Customer does not exist";
            }
            return "An error occured";
        }
         

        private bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false; // Invalid if null or empty
            }

            char firstChar = name[0];

            // Check if the first character is a digit or a lowercase letter a, b, or c
            if (char.IsDigit(firstChar) || (firstChar >= 'A' && firstChar <= 'C'))
            {
                return false; // Invalid if condition is met
            }

            return true; // Valid name
        }



    }
}
