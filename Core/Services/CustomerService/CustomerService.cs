using Data;
using Data.Dtos;
using Data.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                bool validName = ValidateName(createCustomerDto.FirstName);
                if (validName == false)
                {
                    return "invalid First Name supplied";
                }

                bool validLastName = ValidateName(createCustomerDto.LastName);
                if (validLastName == false)
                {
                    return "invalid Last Name supplied";
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


        //private string ValidateName(string name)
        //{
        //    if (string.IsNullOrWhiteSpace(name) || char.IsDigit(name[0]) || "ABC".Contains(char.ToUpper(name[0])))
        //    {
        //        return name;
        //    }
        //    return string.Empty;
        //}


        public bool ValidateName(string name)
        {
            //if (string.IsNullOrWhiteSpace(name))
            //{
            //    return false;
            //}

            string pattern = @"^[A-ZÀ-ÖØ-öø-ÿ][A-Za-zÀ-ÖØ-öø-ÿ' -]{1,49}$";
            // Ensures the first letter is uppercase and the name is 2-50 characters long

            if (Regex.IsMatch(name, pattern))
            {
                return true;
            }

            return false;
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
