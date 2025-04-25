namespace Api.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
