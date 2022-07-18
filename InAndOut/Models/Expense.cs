using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key] //Sets a primary key
        public int ID { get; set; }

        [DisplayName("Expense")]
        public string ExpenseName { get; set; }
        
        public int Amount { get; set; }
    }
}
