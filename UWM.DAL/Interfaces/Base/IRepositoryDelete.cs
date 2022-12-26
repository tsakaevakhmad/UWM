namespace UWM.DAL.Interfaces.Base
{
    public interface IRepositoryDelete<Entity> where Entity : class
    {
        void Delete(int id);
    }
}
