namespace UWM.Domain.DTO.Items
{
    public class ItemListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public int ProviderId { get; set; }
        public int WarehouseId { get; set; }
        public int SubCategoryId { get; set; }
        public string? ProviderName { get; set; }
    }
}
