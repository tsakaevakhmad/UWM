using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UWM.DAL.Data;
namespace UWM.NUnit.Tests
{
    internal static class ClientForTests
    {
        public static HttpClient GetClient() 
        {
            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var dbContextDescriptor = services.SingleOrDefault(desc =>
                    desc.ServiceType == typeof(DbContextOptions<AppDBContext>));

                    services.Remove(dbContextDescriptor);

                    services.AddDbContext<AppDBContext>(opt =>
                    {
                        opt.UseSqlServer("Data Source=localhost,1433;Database=master;User ID=sa;Password=P@ssword;Persist Security Info=False;");
                    });
                });
            });
            
            return webHost.CreateClient();  
        }
    }
}
