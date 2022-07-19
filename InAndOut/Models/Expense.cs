using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        //Creating a foreign key manually: 
        [DisplayName("Expense Type")]
        public int ExpenseTypeId { get; set; }

        
        //Then using DataAnnotations.Schema - define the virtual expense type as the foreign key
        [ForeignKey("ExpenseTypeId")]
        //This will automatically create the foreign key relation. However, you can manually do it as well
        public virtual ExpenseType ExpenseType { get; set; }
    }
}
