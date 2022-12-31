using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http.Json;
using System.Net;
using UWM.Domain.DTO.Watehouses;
using UWM.Domain.DTO.Providers;

namespace UWM.NUnit.Tests.ControllersTest
{
    public class ProviderTest
    {
        private int id;
        private readonly HttpClient client = ClientForTests.GetClient();

        [Test]
        public async Task A_Post_ShouldBeOkAndIsNotNull()
        {
            // Arrange
            var provider = new ProviderDto
            {
                Name = "Test"
            };
            string json = JsonConvert.SerializeObject(provider);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            
            // Act
            HttpResponseMessage response = await client.PostAsync("api/Provider", httpContent);
            var res = await response.Content.ReadFromJsonAsync<int>();
            id = res;
            
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(res > 0);
        }

        [Test]
        public async Task B_GetAll_ShouldBeOkAndIsNotNull()
        {
            // Arrange

            // Act
            HttpResponseMessage response = await client.GetAsync("api/Provider");
            var res = await response.Content.ReadFromJsonAsync<IEnumerable<ProviderDto>>();
            
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(res.FirstOrDefault(), "provider is Null");
        }

        [Test]
        public async Task E_Put_ShouldBeOk()
        {
            // Arrange
            var provider = new ProviderDto
            {
                Id = id,
                Name = "Обновлен"
            };
            string json = JsonConvert.SerializeObject(provider);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await client.PutAsync($"api/Provider/{id}", httpContent);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task F_Delete_ShouldBeOk()
        {
            // Arrange

            // Act
            HttpResponseMessage response = await client.DeleteAsync($"api/Provider/{id}");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
