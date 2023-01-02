using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using UWM.Domain.DTO.Watehouses;

namespace UWM.NUnit.Tests.ControllersTest
{

    public class AddressTest
    {
        private readonly HttpClient client = ClientForTests.GetClient();

        [Test]
        public async Task E_Put_ShouldBeOk()
        {
            // Arrange
            var address = new AddressDto
            {
                Id = 1,
                Country = "NewYork",
                City = "USA",
                Building = "44",
                WarehouseId = 1,
            };
            string json = JsonConvert.SerializeObject(address);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await client.PutAsync($"api/Address/1", httpContent);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
