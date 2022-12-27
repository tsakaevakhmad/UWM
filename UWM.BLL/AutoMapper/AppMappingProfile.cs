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
            CreateMap<ItemDto, Item>().ReverseMap()
                .ForMember(w => w.WarehouseNumber, wn => wn.MapFrom(f => f.Warehouse.Number))
                .ForMember(p => p.ProviderName, pn => pn.MapFrom(f => f.Provider.Name))
                .ForMember(c => c.SubCategoryName, cn => cn.MapFrom(f => f.SubCategory.Name));
                
            
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
