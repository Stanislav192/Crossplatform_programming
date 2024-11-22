using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
