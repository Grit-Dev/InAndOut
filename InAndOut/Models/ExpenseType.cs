using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class ExpenseType
    {
        /// <summary>
        /// PLEASE NOTE: IMPORTANT: When creating the model make sure to put key, and Required data Annotations first before doing a migration 
        /// and updating the database. This is because of the nullable issue I was running into 
        /// </summary>

        [Key] //Primary Key
        public int ID { get; set; }

        [DisplayName("Expense Type")] // Will display this this as the front end
        
        public string Name { get; set; }
    }
}
