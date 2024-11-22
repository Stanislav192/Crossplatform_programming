using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string GenderMFU { get; set; }
        public string ContactDetails { get; set; }
        public string OtherDetails { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
