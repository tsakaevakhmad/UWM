namespace UWM.DAL.Interfaces.Base
{
    public interface IRepositoryUpdate<Entity> where Entity : class
    {
        Task Update(Entity item);
    }
}
