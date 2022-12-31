using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http.Json;
using System.Net;
using UWM.Domain.DTO.Items;
using UWM.Domain.DTO.Watehouses;
using System.Configuration.Provider;

namespace UWM.NUnit.Tests.ControllersTest
{
    [TestFixture]
    public class WarehouseTest
    {
        private int id;
        private readonly HttpClient client = ClientForTests.GetClient();
        
        [Test]
        public async Task A_Post_ShouldBeOkAndIsNotNull()
        {
            // Arrange
            var warehouse = new WarehouseDto
            {
                Number = "Новый",
                AddressDto = new AddressDto 
                { 
                    Country = "USA", 
                    City = "Miamy", 
                    Building = "12" 
                }
            };
            string json = JsonConvert.SerializeObject(warehouse);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            
            // Act
            HttpResponseMessage response = await client.PostAsync("api/Warehouse", httpContent);
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
            HttpResponseMessage response = await client.GetAsync("api/Warehouse");
            var res = await response.Content.ReadFromJsonAsync<IEnumerable<WarehouseDto>>();
            var address = res.Select(a => a.AddressDto).FirstOrDefault();
            
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(address, "address is Null");
        }

        [Test]
        public async Task E_Put_ShouldBeOk()
        {
            // Arrange
            var warehouse = new WarehouseDto
            {
                Id = id,
                Number = "Обновлен"
            };
            string json = JsonConvert.SerializeObject(warehouse);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await client.PutAsync($"api/Warehouse/{id}", httpContent);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task F_Delete_ShouldBeOk()
        {
            // Arrange

            // Act
            HttpResponseMessage response = await client.DeleteAsync($"api/Warehouse/{id}");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
