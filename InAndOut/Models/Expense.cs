using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key] //Sets a primary key
        public int ID { get; set; }

       /* [DisplayName("Expense")]
        [Required]*/
        public string ExpenseName { get; set; }
       /* [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0!")]*/
        public int Amount { get; set; }
    }
}
