using UWM.Domain.Entity;

namespace UWM.Domain.DTO
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Specifications { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public int ProviderId { get; set; }
        public int WarehouseId { get; set; }
        public int SubCategoryId { get; set; }
        public string? ProviderName { get; set; }
        public string? WarehouseNumber { get; set; }
        public string? SubCategoryName { get; set; }
    }
}
