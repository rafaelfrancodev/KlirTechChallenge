using FluentAssertions;
using Klir.TechChallenge.Application.CheckoutAppService;
using Klir.TechChallenge.Application.CheckoutAppService.Input;
using Klir.TechChallenge.Domain.Entities;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Infra.Fakers;
using Moq;
using System.Linq;
using Xunit;

namespace Klir.TechChallenge.Tests.Application.CheckoutAppServiceTest
{
    public class CheckoutAppServiceTest
    {
        private readonly Mock<ICheckoutDomainService> _checkoutDomainServiceMock;
        private CheckoutAppService _checkoutAppService;

        public CheckoutAppServiceTest()
        {
            _checkoutDomainServiceMock = new Mock<ICheckoutDomainService>();
            _checkoutAppService = new CheckoutAppService(_checkoutDomainServiceMock.Object);
        }

        [Fact]
        public void ShouldCartItemBeEmpty()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.Create();
            _checkoutDomainServiceMock.Setup(x => x.GetCheckout()).Returns(shoppingCartItems);


            //act
            var result = _checkoutAppService.GetCheckout();
            
            // assert
            result.Products.Count.Should().Be(0);
            result.Total.Should().Be(0);
        }

        [Fact]
        public void ShouldAddCartItemCheckoutWhenDoesntExistsProductInShoppingCartItem()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.CreateWithProducts();
            var shoppingCartItem = shoppingCartItems.Products.FirstOrDefault();
            var shoppingCartItemProduct = new ShoppingCartItemProductInput() { Id = shoppingCartItem.Product.Id, Name = shoppingCartItem.Product.Name};
            var shoppingCartInput =
                new ShoppingCartItemInput(shoppingCartItem.Id, shoppingCartItem.CheckoutId, shoppingCartItemProduct,
                    shoppingCartItem.Quantity);
            _checkoutDomainServiceMock.Setup(x => x.AddCartItem(It.IsAny<ShoppingCartItem>())).Returns(shoppingCartItems);

            //act
            var result = _checkoutAppService.AddCartItem(shoppingCartInput);

            //asset
            result.Products.Count.Should().Be(1);
            result.Products.FirstOrDefault().Quantity.Should().Be(1);
            result.Total.Should().Be(20);

        }

        [Fact]
        public void ShouldUpdateCartItemCheckoutWhenDoesExistsProductInShoppingCartItem()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.CreateWithProducts();
            var shoppingCartItem = shoppingCartItems.Products.FirstOrDefault();
            var shoppingCartItemProduct = new ShoppingCartItemProductInput() { Id = shoppingCartItem.Product.Id, Name = shoppingCartItem.Product.Name };
            var shoppingCartInput =
                new ShoppingCartItemInput(shoppingCartItem.Id, shoppingCartItem.CheckoutId, shoppingCartItemProduct,
                    shoppingCartItem.Quantity);
            _checkoutDomainServiceMock.SetupSequence(x => x.AddCartItem(It.IsAny<ShoppingCartItem>())).Returns(shoppingCartItems);
            shoppingCartItem.SetQuantity(2);
            shoppingCartItems.Products.FirstOrDefault().Quantity = 2;
            _checkoutDomainServiceMock.SetupSequence(x => x.AddCartItem(It.IsAny<ShoppingCartItem>())).Returns(shoppingCartItems);

            //act
            var result = _checkoutAppService.AddCartItem(shoppingCartInput);

            //asset
            result.Products.Count.Should().Be(1);
            result.Products.FirstOrDefault().Quantity.Should().Be(2);
            result.Products.FirstOrDefault().Total.Should().Be(40);
            result.Total.Should().Be(40);
        }

        [Fact]
        public void ShouldRemoveCartItemCheckoutWhenDoesExistsProductInShoppingCartItem()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.CreateWithProducts();
            var shoppingCartItemsEmpty = CheckoutFaker.Create();
            var shoppingCartItem = shoppingCartItems.Products.FirstOrDefault();
            var shoppingCartItemProduct = new ShoppingCartItemProductInput() { Id = shoppingCartItem.Product.Id, Name = shoppingCartItem.Product.Name };
            var shoppingCartInput =
                new ShoppingCartItemInput(shoppingCartItem.Id, shoppingCartItem.CheckoutId, shoppingCartItemProduct
                    ,
                    shoppingCartItem.Quantity);

            _checkoutDomainServiceMock.Setup(x => x.RemoveCartItem(It.IsAny<ShoppingCartItem>())).Returns(shoppingCartItemsEmpty);
            

            //act
            var result = _checkoutAppService.RemoveCartItem(shoppingCartInput);

            //asset
            result.Products.Count().Should().Be(0);
            result.Total.Should().Be(0);
        }
    }
}
