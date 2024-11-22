using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Book_Category
    {
        [Key]
        public string BookCategoryCode { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
