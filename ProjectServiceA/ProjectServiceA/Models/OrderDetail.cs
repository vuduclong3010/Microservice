using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ProjectServiceA.Models
{
    public class OrderDetail
    {
        public string Id { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }

        public decimal Total { get; set; }

        public int ReturnQty { get; set; }

        public string IdProduct { get; set; }

        [ForeignKey("IdProduct")]

        public Product Products { set; get; }

        public string OrderId { get; set; }

        [ForeignKey("OrderId")]

        public virtual Order Order { set; get; }
    }
}
