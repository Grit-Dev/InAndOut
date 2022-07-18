using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key] //Sets a primary key
        public int ID { get; set; }

    /*    [DisplayName("Expense")]
        [Required] //Validation - Must be entered in */
        [StringLength(30, MinimumLength = 3, ErrorMessage ="Expense name must be minium of 3 characters, and max of 30")]
        public string ExpenseName { get; set; }

        [Required]
    /*    [Range(1, int.MaxValue,ErrorMessage ="Amount must be greater than zero")]*/
        public int Amount { get; set; }
    }
}
