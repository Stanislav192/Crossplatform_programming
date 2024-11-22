using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [ForeignKey("ContactType")]
        public string ContactTypeCode { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string OtherDetails { get; set; }

        public virtual Ref_Contact_Type ContactType { get; set; }
    }
}
