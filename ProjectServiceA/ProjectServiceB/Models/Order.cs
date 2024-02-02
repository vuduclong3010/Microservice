using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectServiceB.Models
{
    public class Order
    {
        public string Id { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalMoney { get; set; }

        public string Node { get; set; }

        public string NameReciver { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsDelete { get; set; }

        public string IsActive { get; set; }

        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]

        public virtual Customer Customers { set; get; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
