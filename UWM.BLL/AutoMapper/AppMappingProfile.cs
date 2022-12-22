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

            CreateMap<WarehoseDto, Warehouse>();
            
            CreateMap<CategoryDto, Category>();
            
            CreateMap<SubCategoryDto, SubCategory>();
            
            CreateMap<ProviderDto, Provider>();
        }
    }
}
