using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectServiceB.Dto
{
    public class OrderDto
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
    }
}
