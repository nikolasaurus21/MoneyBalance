using System.ComponentModel.DataAnnotations;
namespace MoneyBalance.Models
{
    public class MBHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime ExpensesDate   { get; set; }
        public string ExpensesDescription { get; set; } = null!;
        public double ProductPrice { get; set; }
    }
}
