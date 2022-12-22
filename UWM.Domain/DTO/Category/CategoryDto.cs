using UWM.Domain.DTO.SubCategory;

namespace UWM.Domain.DTO.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategoryDto>? SubCategoryDto { get; set; } 
    }
}
