using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Item
    {
        /// <summary>
        /// PLEASE NOTE: IMPORTANT: When creating the model make sure to put key, and Required data Annotations first before doing a migration 
        /// and updating the database. This is because of the nullable issue I was running into 
        /// </summary>
        /// 


        [Key] // Sets the primary key and increments by one
        public int ID { get; set; }

        //Data Annotations used to make sure it displays correctly the name
        [DisplayName("Borrower Name")]
        public string Borrower { get; set;}

        [DisplayName("Lender name")]
        public string LenderName { get; set; }

        [DisplayName("Item name")]
        public string ItemName { get; set; }

        
    }
}
