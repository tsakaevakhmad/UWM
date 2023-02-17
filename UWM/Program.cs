using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UWM.BLL.Interfaces;
using UWM.BLL.Services;
using UWM.DAL.AutoMapper;
using UWM.DAL.Data;
using UWM.DAL.Interfaces.Categories;
using UWM.DAL.Interfaces.Items;
using UWM.DAL.Interfaces.Providers;
using UWM.DAL.Interfaces.SubCategories;
using UWM.DAL.Interfaces.Warehouses;
using UWM.DAL.Repositories;
using UWM.Domain.JWT;
using UWM.Domain.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("secrets.json");
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetSection("DB").Value;
builder.Services.AddDbContext<AppDBContext>(option => option.UseSqlServer(connection));

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWT"));
builder.Services.Configure<MailConfig>(builder.Configuration.GetSection("MailConfig"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
                opt =>
                {
                    opt.Password.RequireDigit = false;
                    opt.Password.RequiredLength = 8;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireUppercase = false;
                    opt.User.RequireUniqueEmail = true;
                    opt.SignIn.RequireConfirmedEmail = true;
                })
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<AppDBContext>()
                .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration.GetSection("JWT:Issuer").Value,
        ValidateAudience = true,
        ValidAudience = builder.Configuration.GetSection("JWT:Audience").Value,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:SecretKey").Value)),
        ValidateIssuerSigningKey = true
    };
});

//Services
builder.Services.AddTransient<IItemServices, ItemServices>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddTransient<IProviderServices, ProviderServices>();
builder.Services.AddTransient<ISubCategoryServices, SubCategoryServices>();
builder.Services.AddTransient<IWarehouseServices, WarehouseServices>();
builder.Services.AddTransient<IAuthorizationServices, AuthorizationServices>();
builder.Services.AddTransient<IAdminServices, AdminServices>();

//Repositories
builder.Services.AddScoped<IItemRepository, ItemRepository>();
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

string cors = builder.Configuration.GetSection("Cors").Value;
if (cors != null)
{
    cors.Split(",");
    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins(cors));
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }