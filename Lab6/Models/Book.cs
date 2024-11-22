using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        [ForeignKey("BookCategory")]
        public string BookCategoryCode { get; set; }

        public string ISBN { get; set; }
        public DateTime? DateOfPublication { get; set; }
        public DateTime? DateAcquired { get; set; }
        public string Title { get; set; }
        public decimal? RecommendedPrice { get; set; }
        public string Comments { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book_Category BookCategory { get; set; }
        public virtual ICollection<Order_Item> OrderItems { get; set; }


    }
}
