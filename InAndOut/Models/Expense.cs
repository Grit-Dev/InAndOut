using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expense
    {
        /// <summary>
        /// PLEASE NOTE: IMPORTANT: When creating the model make sure to put key, and Required data Annotations first before doing a migration 
        /// and updating the database. This is because of the nullable issue I was running into 
        /// </summary>

        [Key] //Sets a primary key
        public int ID { get; set; }

        /* [DisplayName("Expense")]
         [Required]*/
        [DisplayName("Expenses")]
        public string ExpenseName { get; set; }
       /* [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0!")]*/
        public int Amount { get; set; }
    }
}
