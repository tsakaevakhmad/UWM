namespace UWM.Domain.DTO.Watehouses
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Building { get; set; }
        public int WarehouseId { get; set; }
    }
}
