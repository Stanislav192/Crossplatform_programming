using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal? OrderValue { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Order_Item> OrderItems { get; set; }

    }
}
