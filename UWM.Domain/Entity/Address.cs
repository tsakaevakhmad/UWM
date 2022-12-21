namespace UWM.Domain.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Building { get; set; }
        public WarehouseDto Warehouse { get; set; }
    }
}
