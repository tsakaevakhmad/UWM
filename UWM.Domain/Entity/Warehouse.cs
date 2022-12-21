namespace UWM.Domain.Entity
{
    public class WarehouseDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<Item> Items { get; set; }
    }
}
