namespace UWM.Domain.Entity
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }
    }
}
