namespace UWM.DAL.Interfaces.Base
{
    public interface IRepositoryUpdate<Entity> where Entity : class
    {
        void Update(Entity item);
    }
}
