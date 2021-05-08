using FluentAssertions;
using Klir.TechChallenge.Application.ProductAppService.ViewModel;
using Klir.TechChallenge.Tests.Integraded.Config;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Klir.TechChallenge.Tests.Integraded.Scenarios.GetProductsWithPromotion
{
    public class GetProductsWithPromotionTest
    {
        private readonly AppFixture _factory;

        public GetProductsWithPromotionTest()
        {
            _factory = new AppFixture();
        }


        [Fact]
        public async Task ShouldGetProductsWithPromotion()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync($"/api/v1/products");

            var jsonString = await response.Content.ReadAsStringAsync();
            var viewModelResult = JsonConvert.DeserializeObject<IEnumerable<ProductWithPromotionViewModel>>(jsonString);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
