using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Order_Item
    {
        [Key]
        public int ItemNumber { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        public decimal? AgreedPrice { get; set; }
        public string Comment { get; set; }

        public virtual Order Order { get; set; }
        public virtual Book Book { get; set; }
    }
}
