using FluentAssertions;
using Klir.TechChallenge.Application.CheckoutAppService.Mappers;
using Klir.TechChallenge.Application.Interfaces;
using Klir.TechChallenge.Infra.Fakers;
using Klir.TechChallenge.Web.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using Klir.TechChallenge.Application.CheckoutAppService.Input;
using Xunit;

namespace Klir.TechChallenge.Tests.Controllers
{
    public class CheckoutControllerTest
    {
        private readonly Mock<ICheckoutAppService> _checkoutAppServiceMock;
        private CheckoutController _checkoutController;

        public CheckoutControllerTest()
        {
            _checkoutAppServiceMock = new Mock<ICheckoutAppService>();
            _checkoutController = new CheckoutController(_checkoutAppServiceMock.Object);
        }

        [Fact]
        public void ShouldGetDataCheckout()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.CreateWithProducts();
            _checkoutAppServiceMock.Setup(x => x.GetCheckout()).Returns(shoppingCartItems.MapperCheckoutDomainToViewModel());

            //act
            var result = _checkoutController.Get();

            //assert
            var okObjectResult = (OkObjectResult)result;
            okObjectResult.StatusCode.Should().Be(200);
            _checkoutAppServiceMock.Verify(x => x.GetCheckout(), Times.Once);
        }

        [Fact]
        public void ShouldAddItem()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.CreateWithProducts();
            var shoppingCartItem = shoppingCartItems.Products.FirstOrDefault();
            var shoppingCartItemProduct = new ShoppingCartItemProductInput() { Id = shoppingCartItem.Product.Id, Name = shoppingCartItem.Product.Name };
            var shoppingCartInput =
                new ShoppingCartItemInput(shoppingCartItem.Id, shoppingCartItem.CheckoutId, shoppingCartItemProduct,
                    shoppingCartItem.Quantity);
            _checkoutAppServiceMock.Setup(x => x.AddCartItem(It.IsAny<ShoppingCartItemInput>())).Returns(shoppingCartItems.MapperCheckoutDomainToViewModel());

            //act
            var result = _checkoutController.Post(shoppingCartInput);

            //assert
            var okObjectResult = (OkObjectResult)result;
            okObjectResult.StatusCode.Should().Be(200);
            _checkoutAppServiceMock.Verify(x => x.AddCartItem(It.IsAny<ShoppingCartItemInput>()), Times.Once);
        }

        [Fact]
        public void ShouldRemoveItem()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.Create();
            _checkoutAppServiceMock.Setup(x => x.RemoveCartItem(It.IsAny<int>())).Returns(shoppingCartItems.MapperCheckoutDomainToViewModel());

            //act
            var result = _checkoutController.Delete(1);

            //assert
            var okObjectResult = (OkObjectResult)result;
            okObjectResult.StatusCode.Should().Be(200);
            _checkoutAppServiceMock.Verify(x => x.RemoveCartItem(It.IsAny<int>()), Times.Once);
        }
    }
}
