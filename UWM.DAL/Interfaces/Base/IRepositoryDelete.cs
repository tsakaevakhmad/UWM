namespace UWM.DAL.Interfaces.Base
{
    public interface IRepositoryDelete<Entity> where Entity : class
    {
        Task Delete(int id);
    }
}
