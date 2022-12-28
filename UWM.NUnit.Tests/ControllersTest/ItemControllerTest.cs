using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http.Json;
using UWM.Domain.DTO.Items;

namespace UWM.NUnit.Tests.ControllersTest
{
    [TestFixture]
    public class ItemControllerTest
    {
        private int id;
        private int subcatId;

        [Test]
        public async Task APost_ShouldBeOk()
        {
            // Arrange

            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });

            HttpClient client = webHost.CreateClient();
            var item = new ItemDto
            {
                Title = "Topic",
                ProviderId = 1,
                Price = 200,
                Unit = "units",
                Manufacturer = "Gucci",
                Quantity = 1,
                Specifications = "For something",
                SubCategoryId = 6,
                WarehouseId = 2
            };
            string json = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            // Act

            HttpResponseMessage response = await client.PostAsync("api/Item", httpContent);
            var res = await response.Content.ReadFromJsonAsync<int>();
            id = res;
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(res > 0);
        }

        [Test]
        public async Task BGet_All_ShouldBeOkAndIsNotNull()
        {
            // Arrange

            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });

            HttpClient client = webHost.CreateClient();

            // Act

            HttpResponseMessage response = await client.GetAsync("api/item");
            var res = await response.Content.ReadFromJsonAsync<IEnumerable<ItemDto>>();
            var providerName = res.Select(s => s.ProviderName).FirstOrDefault();
            
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(providerName, "providerName is Null");

        }

        [Test]
        public async Task CGet_ById_ShouldBeOkAndIsNotNull()
        {
            // Arrange

            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });

            HttpClient client = webHost.CreateClient();

            // Act

            HttpResponseMessage response = await client.GetAsync($"api/item/{id}");
            var res = await response.Content.ReadFromJsonAsync<ItemDto>();
            subcatId = res.SubCategoryId;
            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(id, res.Id);
            Assert.IsNotNull(res.SubCategoryName, "SubCategoryName is Null");
            Assert.IsNotNull(res.WarehouseNumber, "WarehouseNumber is Null");
            Assert.IsNotNull(res.ProviderName, "ProviderName is Null");
        }

        [Test]
        public async Task DGet_BySubCategry_ShouldBeOkAndIsNotNull()
        {
            // Arrange

            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });

            HttpClient client = webHost.CreateClient();

            // Act

            HttpResponseMessage response = await client.GetAsync($"api/Item/GetBySubCategory/{subcatId}");
            var res = await response.Content.ReadFromJsonAsync<IEnumerable<ItemListDto>>();
            var providerName = res.Select(s => s.ProviderName).FirstOrDefault();
            var subCategoryId = res.Select(s => s.SubCategoryId).FirstOrDefault();

            // Assert

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(subcatId, subCategoryId);
            Assert.IsNotNull(providerName, "providerName is Null");
        }

        [Test]
        public async Task EPut_ShouldBeOk()
        {
            // Arrange
            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });

            HttpClient client = webHost.CreateClient();
            var item = new ItemDto
            {
                Id = id,
                Title = "Jeance",
                ProviderId = 2,
                Price = 3,
                Unit = "units",
                Manufacturer = "Luxary",
                Quantity = 1,
                Specifications = "For me",
                SubCategoryId = 6,
                WarehouseId = 2
            };
            string json = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            
            // Act
            HttpResponseMessage response = await client.PutAsync($"api/Item/{id}", httpContent);
            
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task FDelete_ShouldBeOk()
        {
            // Arrange
            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });

            HttpClient client = webHost.CreateClient();
            
            // Act
            HttpResponseMessage response = await client.DeleteAsync($"api/Item/{id}");
            
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
