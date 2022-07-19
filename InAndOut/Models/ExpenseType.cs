using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class ExpenseType
    {
        [Key] //Primary Key
        public int ID { get; set; }

        [DisplayName("Expense Type")] // Will display this this as the front end
        
        public string Name { get; set; }
    }
}
