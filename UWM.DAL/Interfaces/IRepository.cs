namespace UWM.DAL.Interfaces
{
    public interface IRepository<Entity> where Entity : class
    {
        void Create(Entity item);
        Entity Get(int id);
        IEnumerable<Entity> GetAll();
        void Delete(int id);
        void Update(Entity item);
    }
}
