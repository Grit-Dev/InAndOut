using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Item
    {
        [Key] // Sets the primary key and increments by one
        public int ID { get; set; }

        public string Borrower { get; set;}
    }
}
