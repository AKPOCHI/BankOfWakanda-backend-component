

using System.ComponentModel.DataAnnotations;

namespace Data.Dtos
{
    public class CreateCustomerDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        //data anotation validation
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PassWord { get; set; }
    }
}
