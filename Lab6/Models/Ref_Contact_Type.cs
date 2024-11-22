using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Ref_Contact_Type
    {
        [Key]
        public string ContactTypeCode { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
