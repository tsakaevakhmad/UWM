using UWM.DAL.Interfaces.Base;
using UWM.Domain.Entity;

namespace UWM.DAL.Interfaces.SubCategories
{
    public interface ISubCategoryRepository : IRepositoryGetAll<SubCategory>, IRepositoryCreate<SubCategory>,
        IRepositoryUpdate<SubCategory>, IRepositoryDelete<SubCategory>
    {
    }
}
