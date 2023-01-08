using Microsoft.EntityFrameworkCore;
using System.Linq;
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

builder.Configuration.AddJsonFile("secrets.json");
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = builder.Configuration.GetSection("uwm-main-db").Value;
builder.Services.AddDbContext<AppDBContext>(option => option.UseSqlServer(connection));

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddTransient<IItemServices, ItemServices>();
builder.Services.AddTransient<IAddressServices, AddressServices>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddTransient<IProviderServices, ProviderServices>();
builder.Services.AddTransient<ISubCategoryServices, SubCategoryServices>();
builder.Services.AddTransient<IWarehouseServices, WarehouseServices>();

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();

builder.Services.AddCors();

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

var cors = builder.Configuration.GetSection("Cors").Value.Split(",");

if (cors != null)
    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins(cors));

app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }