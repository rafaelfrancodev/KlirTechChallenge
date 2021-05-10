using System.Linq;
using FluentAssertions;
using Klir.TechChallenge.Application.CheckoutAppService.ViewModel;
using Klir.TechChallenge.Tests.Integraded.Config;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Klir.TechChallenge.Application.CheckoutAppService.Input;
using Xunit;

namespace Klir.TechChallenge.Tests.Integraded.Scenarios.CheckoutTest
{
    public class CheckoutTest
    {
        private readonly AppFixture _factory;

        public CheckoutTest()
        {
            _factory = new AppFixture();
        }


        [Fact]
        public async Task ShouldGetDataCheckoutIsEmpty()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync($"/api/v1/checkout");

            var jsonString = await response.Content.ReadAsStringAsync();
            var viewModelResult = JsonConvert.DeserializeObject<CheckoutViewModel>(jsonString);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            viewModelResult.Products.Count.Should().Be(0);
        }

        [Fact]
        public async Task ShouldAddItemAndGetDataCheckout()
        {
            //Arrange
            var input = new ShoppingCartItemInput
            {
                Product = new ShoppingCartItemProductInput()
                {
                    Id = 1,
                    Name = "Product A"
                },
                Quantity = 2
            };
            var client = _factory.CreateClient();
            await client.PostAsync("/api/v1/checkout", ContentHelper<object>.FormatStringContent(input));

            //Act
            var response = await client.GetAsync($"/api/v1/checkout");

            var jsonString = await response.Content.ReadAsStringAsync();
            var viewModelResult = JsonConvert.DeserializeObject<CheckoutViewModel>(jsonString);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            viewModelResult.Products.Count.Should().Be(1);
            viewModelResult.Total.Should().Be(20);
        }

        [Fact]
        public async Task ShouldAddItemsWithPromotionAndGetDataCheckout()
        {
            //Arrange
            var client = _factory.CreateClient();
            var input = new ShoppingCartItemInput
            {
                Product = new ShoppingCartItemProductInput()
                {
                    Id = 1,
                    Name = "Product A"
                },
                Quantity = 2
            };
            await client.PostAsync("/api/v1/checkout", ContentHelper<object>.FormatStringContent(input));
            input.Product.Id = 2;
            input.Product.Name = "Product B";
            input.Quantity = 5;
            await client.PostAsync("/api/v1/checkout", ContentHelper<object>.FormatStringContent(input));


            //Act
            var response = await client.GetAsync($"/api/v1/checkout");

            var jsonString = await response.Content.ReadAsStringAsync();
            var viewModelResult = JsonConvert.DeserializeObject<CheckoutViewModel>(jsonString);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            viewModelResult.Products.Count.Should().Be(2);
            viewModelResult.Products.Where(x => x.Product.Promotion != null).ToList().Count.Should().Be(2);
            viewModelResult.Total.Should().Be(38);
        }

        [Fact]
        public async Task ShouldAddItemsAndGetDataCheckout()
        {
            //Arrange
            var client = _factory.CreateClient();
            var input = new ShoppingCartItemInput
            {
                Product = new ShoppingCartItemProductInput()
                {
                    Id = 1,
                    Name = "Product A"
                },
                Quantity = 2
            };
            await client.PostAsync("/api/v1/checkout", ContentHelper<object>.FormatStringContent(input));
            input.Product.Id = 2;
            input.Product.Name = "Product B";
            input.Quantity = 5;
            await client.PostAsync("/api/v1/checkout", ContentHelper<object>.FormatStringContent(input));
            input.Product.Id = 3;
            input.Product.Name = "Product C";
            input.Quantity = 5;
            await client.PostAsync("/api/v1/checkout", ContentHelper<object>.FormatStringContent(input));


            //Act
            var response = await client.GetAsync($"/api/v1/checkout");

            var jsonString = await response.Content.ReadAsStringAsync();
            var viewModelResult = JsonConvert.DeserializeObject<CheckoutViewModel>(jsonString);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            viewModelResult.Products.Count.Should().Be(3);
            viewModelResult.Products.Where(x => x.Product.Promotion != null).ToList().Count.Should().Be(2);
            viewModelResult.Products.Where(x => x.Product.Promotion == null).ToList().Count.Should().Be(1);
            viewModelResult.Total.Should().Be(48);
        }

        [Fact]
        public async Task ShouldRemoveItemAndGetDataCheckout()
        {
            //Arrange
            var client = _factory.CreateClient();
            var input = new ShoppingCartItemInput
            {
                Product = new ShoppingCartItemProductInput()
                {
                    Id = 1,
                    Name = "Product A"
                },
                Quantity = 2
            };
            await client.PostAsync("/api/v1/checkout", ContentHelper<object>.FormatStringContent(input));
            input.Product.Id = 2;
            input.Product.Name = "Product B";
            input.Quantity = 5;
            await client.PostAsync("/api/v1/checkout", ContentHelper<object>.FormatStringContent(input));
            input.Product.Id = 3;
            input.Product.Name = "Product C";
            input.Quantity = 5;
            await client.PostAsync("/api/v1/checkout", ContentHelper<object>.FormatStringContent(input));
            await client.DeleteAsync("/api/v1/checkout/3");


            //Act
            var response = await client.GetAsync($"/api/v1/checkout");

            var jsonString = await response.Content.ReadAsStringAsync();
            var viewModelResult = JsonConvert.DeserializeObject<CheckoutViewModel>(jsonString);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            viewModelResult.Products.Count.Should().Be(2);
            viewModelResult.Products.Where(x => x.Product.Promotion != null).ToList().Count.Should().Be(2);
            viewModelResult.Products.Where(x => x.Product.Promotion == null).ToList().Count.Should().Be(0);
            viewModelResult.Total.Should().Be(38);
        }
    }
}
