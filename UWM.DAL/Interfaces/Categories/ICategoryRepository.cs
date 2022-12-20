using UWM.DAL.Interfaces.Base;
using UWM.Domain.Entity;

namespace UWM.DAL.Interfaces.Categories
{
    public interface ICategoryRepository : IRepositoryGetAll<Category>, IRepositoryGet<Category>, 
        IRepositoryCreate<Category>, IRepositoryDelete<Category>, IRepositoryUpdate<Category>
    {
    }
}
