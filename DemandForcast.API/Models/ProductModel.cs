namespace DemandForcast.API.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Rate { get; set; }

        public decimal? Total { get; set; }
    }
}
