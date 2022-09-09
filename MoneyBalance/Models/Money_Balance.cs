using System.ComponentModel.DataAnnotations;
namespace MoneyBalance.Models
{
    public class Money_Balance
    {
        [Key]
        public int Id { get; set; }
        public double Balance { get; set; }
        public double Expenses { get; set; }
        public double Saved { get; set; }
        public double Salary { get; set; }
    }
}
