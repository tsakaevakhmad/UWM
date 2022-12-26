namespace UWM.Domain.DTO.Watehouses
{
    public class WarehouseDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public AddressDto? AddressDto { get; set; }
    }
}
