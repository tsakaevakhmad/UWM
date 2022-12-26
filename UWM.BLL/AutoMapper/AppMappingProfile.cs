using AutoMapper;
using UWM.Domain.DTO.Category;
using UWM.Domain.DTO.Items;
using UWM.Domain.DTO.Providers;
using UWM.Domain.DTO.SubCategory;
using UWM.Domain.DTO.Watehouses;
using UWM.Domain.Entity;

namespace UWM.DAL.AutoMapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<ItemDto, Item>()
                .ForMember(w => w.Warehouse.Number, wn => wn.MapFrom(f => f.WarehouseNumber))
                .ForMember(p => p.Provider.Name, pn => pn.MapFrom(f => f.ProviderName))
                .ForMember(c => c.SubCategory.Name, cn => cn.MapFrom(f => f.SubCategoryName))
                .ReverseMap();
            
            CreateMap<AddressDto, Address>().ReverseMap();

            CreateMap<WarehouseDto, Warehouse>()
                .ForMember(w => w.Address, a => a.MapFrom(a => a.AddressDto))
                .ReverseMap();

            CreateMap<CategoryDto, Category>()
                .ForPath(c => c.SubCategories, sc => sc.MapFrom(s => s.SubCategoryDto))
                .ReverseMap();
            
            CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
            
            CreateMap<ProviderDto, Provider>().ReverseMap();
        }
    }
}
