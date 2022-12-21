namespace UWM.Domain.Entity
{
    public class Item
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
        public Provider Provider { get; set; }
        public WarehouseDto Warehouse { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
