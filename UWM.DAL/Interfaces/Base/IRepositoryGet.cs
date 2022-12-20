namespace UWM.DAL.Interfaces.Base
{
    public interface IRepositoryGet<Entity> where Entity : class
    {
        Task<Entity> Get(int id);
    }
}
