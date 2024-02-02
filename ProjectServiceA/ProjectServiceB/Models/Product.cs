namespace ProjectServiceB.Models
{
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Node { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }

        public bool IsDelete { get; set; }
    }
}
