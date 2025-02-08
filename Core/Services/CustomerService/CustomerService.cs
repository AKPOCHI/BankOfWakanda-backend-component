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

                // Validate names before proceeding
                string invalidName = ValidateName(createCustomerDto.FirstName);
                if (!string.IsNullOrEmpty(invalidName))
                {
                    return $"Invalid {invalidName}. It should not start with a digit or letters A, B, or C.";
                }

                invalidName = ValidateName(createCustomerDto.LastName);
                if (!string.IsNullOrEmpty(invalidName))
                {
                    return $"Invalid {invalidName}. It should not start with a digit or letters A, B, or C.";
                }

                // Validate password
                string passwordError = ValidatePassword(createCustomerDto.PassWord);
                if (!string.IsNullOrEmpty(passwordError))
                {
                    return passwordError;
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


        private string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || char.IsDigit(name[0]) || "ABC".Contains(char.ToUpper(name[0])))
            {
                return name;
            }
            return string.Empty;
        }



        private string ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                return "Password must be at least 8 characters long.";
            }

            if (!password.Any(char.IsUpper))
            {
                return "Password must contain at least one uppercase letter.";
            }

            if (!password.Any(char.IsLower))
            {
                return "Password must contain at least one lowercase letter.";
            }

            if (!password.Any(char.IsDigit))
            {
                return "Password must contain at least one digit.";
            }

            if (!password.Any(ch => "!@#$%^&*()-_+=<>?/.,;:'\"[]{}|".Contains(ch)))
            {
                return "Password must contain at least one special character.";
            }

            return string.Empty; // Password is valid
        }




    }
}
