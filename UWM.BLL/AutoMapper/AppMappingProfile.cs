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

            CreateMap<WarehoseDto, Warehouse>().ReverseMap()
                .ForPath(w => w.AddressDto.WarehouseId, a => a.MapFrom(aw => aw.Address.WarehouseId))
                .ForPath(w => w.AddressDto.Id, a => a.MapFrom(aw => aw.Address.Id))
                .ForPath(w => w.AddressDto.Building, a => a.MapFrom(aw => aw.Address.Building))
                .ForPath(w => w.AddressDto.City, a => a.MapFrom(aw => aw.Address.City))
                .ForPath(w => w.AddressDto.Country, a => a.MapFrom(aw => aw.Address.Country));

            CreateMap<CategoryDto, Category>().ReverseMap()
                .ForPath(c => c.SubCategoryDto, sc => sc.MapFrom(s => s.SubCategories));
            
            CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
            
            CreateMap<ProviderDto, Provider>().ReverseMap();
        }
    }
}
