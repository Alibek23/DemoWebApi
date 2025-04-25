namespace Api.DTOs
{
    public class ProductCreateDto
    {
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
