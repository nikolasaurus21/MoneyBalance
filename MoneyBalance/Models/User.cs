using System.ComponentModel.DataAnnotations;
namespace MoneyBalance.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;


        
    }
}
