namespace DemandForcast.API.Models.DTO.Products
{
    public class AddProductRequestDto
    {
        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Rate { get; set; }

        public decimal? Total { get; set; }
    }
}
