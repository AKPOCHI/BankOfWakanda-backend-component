
using Data.Enum;

namespace Data.Models
{
    public class CustomerAccount
    {
        public Guid Id { get; set;} = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public AccountTypeEnum AccountType { get; set;}
        public decimal AccountBallance { get; set; } = decimal.Zero;
        public string AccountNumber { get; set; }

    }
}


