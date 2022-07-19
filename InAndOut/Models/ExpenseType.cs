using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class ExpenseType
    {
        [Key] //Primary Key
        public int ID { get; set; }

        [DisplayName("Must Have")] // Will display this this as the front end
        public string MustHaves { get; set; }

        [DisplayName("Nice To Have")]
        public string NiceToHave { get; set; }

        [DisplayName("Not Needed")]
        public string NotNeeded { get; set; }

    }
}
