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
                .ForMember(w => w.AddressDto.WarehouseId, a => a.MapFrom(aw => aw.Address.WarehouseId))
                .ForMember(w => w.AddressDto.Id, a => a.MapFrom(aw => aw.Address.Id))
                .ForMember(w => w.AddressDto.Building, a => a.MapFrom(aw => aw.Address.Building))
                .ForMember(w => w.AddressDto.City, a => a.MapFrom(aw => aw.Address.City))
                .ForMember(w => w.AddressDto.Country, a => a.MapFrom(aw => aw.Address.Country));

            CreateMap<CategoryDto, Category>().ReverseMap()
                .ForMember(cd => cd.SubCategoryDto
                .Select(scd => scd.Id), c => c.MapFrom(sc => sc.SubCategories
                .Select(s => s.Id)))
                .ForMember(cd => cd.SubCategoryDto
                .Select(scd => scd.Name), c => c.MapFrom(sc => sc.SubCategories
                .Select(s => s.Name)))
                .ForMember(cd => cd.SubCategoryDto
                .Select(scd => scd.CategoryId), c => c.MapFrom(sc => sc.SubCategories
                .Select(s => s.CategoryId)));
            
            CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
            
            CreateMap<ProviderDto, Provider>().ReverseMap();
        }
    }
}
