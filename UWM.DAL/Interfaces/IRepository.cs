namespace UWM.DAL.Interfaces
{
    public interface IRepository<Entity> where Entity : class
    {
        Task<int> Create(Entity item);
        Task<Entity> Get(int id);
        Task<IEnumerable<Entity>> GetAll();
        Task Delete(int id);
        Task Update(Entity item);
    }
}
