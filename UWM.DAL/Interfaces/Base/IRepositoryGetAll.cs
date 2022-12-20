namespace UWM.DAL.Interfaces.Base
{
    public interface IRepositoryGetAll<Entity> where Entity : class
    {
        Task<IEnumerable<Entity>> GetAll();
    }
}
