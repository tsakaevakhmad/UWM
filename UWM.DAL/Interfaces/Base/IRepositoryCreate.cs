namespace UWM.DAL.Interfaces.Base
{
    public interface IRepositoryCreate<Entity> where Entity : class
    {
        Task<int> Create(Entity item);
    }
}
