using Microsoft.EntityFrameworkCore;
using UWM.BLL.Interfaces;
using UWM.BLL.Services;
using UWM.DAL.AutoMapper;
using UWM.DAL.Data;
using UWM.DAL.Interfaces.Addresses;
using UWM.DAL.Interfaces.Categories;
using UWM.DAL.Interfaces.Items;
using UWM.DAL.Interfaces.Providers;
using UWM.DAL.Interfaces.SubCategories;
using UWM.DAL.Interfaces.Warehouses;
using UWM.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(option => option.UseSqlServer(builder.Configuration["UWMContext"]));
builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddScoped<IItemServices, ItemServices>();
builder.Services.AddScoped<IAddressServices, AddressServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IProviderServices, ProviderServices>();
builder.Services.AddScoped<ISubCategoryServices, SubCategoryServices>();
builder.Services.AddScoped<IWarehouseServices, WarehouseServices>();

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
