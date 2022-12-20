namespace UWM.Domain.DomainModels.Filters
{
    public class ItemFilter
    {
        public string[] Title { get; set; }
        public string[] Specifications { get; set; }
        public string[] Manufacturer { get; set; }
        public string[] ProviderName { get; set; }
        public string[] WarehouseNumber { get; set; }
    }
}
