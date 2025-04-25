namespace Api.DTOs
{
    public class ProductDetailDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string SupplierName { get; set; }
    }
}
