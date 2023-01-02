using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using UWM.DAL.Data;
namespace UWM.NUnit.Tests
{
    public static class ClientForTests
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
                        IConfiguration configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile(@"appsettings.json", false, false)
                        .AddJsonFile(@"secrets.json", false, false)
                        .AddEnvironmentVariables()
                        .Build();

                        var connections = configuration.GetSection("TestDb").Value;
                        opt.UseSqlServer(connections); 
                    });
                });
            });        
            return webHost.CreateClient();  
        }
    }
}
