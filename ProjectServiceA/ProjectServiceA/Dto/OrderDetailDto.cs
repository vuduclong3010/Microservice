using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectServiceA.Dto
{
    public class OrderDetailDto
    {
        public string Id { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }

        public decimal Total { get; set; }

        public int ReturnQty { get; set; }

        public string IdProduct { get; set; }

        public string OrderId { get; set; }
    }
}
