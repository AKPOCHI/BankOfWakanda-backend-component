

namespace Data.Models
{
    public class StatementOfAccount
    {
        public Guid Id { get; set; } = Guid.NewGuid();  
        public Guid AccountId { get; set; } 
        public Guid CustomerId { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public string TypeOfTransaction { get; set; }
        public decimal Amount { get; set; }
        public string Description {get; set; }  
    }
}
