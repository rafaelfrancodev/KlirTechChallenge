using System.Linq;
using FluentAssertions;
using Klir.TechChallenge.Domain.Entities;
using Klir.TechChallenge.Domain.Services;
using Klir.TechChallenge.Infra.Fakers;
using Xunit;

namespace Klir.TechChallenge.Tests.Domain.Services
{
    public class CheckoutDomainServiceTest
    {
        private CheckoutDomainService _checkoutDomainService;

        public CheckoutDomainServiceTest()
        {
            _checkoutDomainService = new CheckoutDomainService();
        }

        [Fact]
        public void ShouldCartItemBeEmpty()
        {
            _checkoutDomainService.GetCheckout().Products.Count.Should().Be(0);
            _checkoutDomainService.GetCheckout().Total.Should().Be(0);

        }

        [Fact]
        public void ShouldAddCartItemCheckoutWhenDoesntExistsProductInShoppingCartItem()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.CreateWithProducts();

            //act
            _checkoutDomainService.AddCartItem(shoppingCartItems.Products.FirstOrDefault());

            //asset
            _checkoutDomainService.GetCheckout().Products.Count.Should().Be(1);
            _checkoutDomainService.GetCheckout().Products.FirstOrDefault().Quantity.Should().Be(1);
            _checkoutDomainService.GetCheckout().Total.Should().Be(20);

        }

        [Fact]
        public void ShouldUpdateCartItemCheckoutWhenDoesExistsProductInShoppingCartItem()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.CreateWithProducts();
            var shoppingCartItem = shoppingCartItems.Products.FirstOrDefault();
            _checkoutDomainService.AddCartItem(shoppingCartItem);

            //act
            shoppingCartItem.SetQuantity(2);
            _checkoutDomainService.AddCartItem(shoppingCartItem);

            //asset
            _checkoutDomainService.GetCheckout().Products.Count.Should().Be(1);
            _checkoutDomainService.GetCheckout().Products.FirstOrDefault().Quantity.Should().Be(2);
            _checkoutDomainService.GetCheckout().Products.FirstOrDefault().Total.Should().Be(40);
            _checkoutDomainService.GetCheckout().Total.Should().Be(40);
        }

        [Fact]
        public void ShouldRemoveCartItemCheckoutWhenDoesExistsProductInShoppingCartItem()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.CreateWithProducts();
            var shoppingCartItem = shoppingCartItems.Products.FirstOrDefault();
            _checkoutDomainService.AddCartItem(shoppingCartItem);

            //act
            _checkoutDomainService.RemoveCartItem(shoppingCartItem);

            //asset
            _checkoutDomainService.GetCheckout().Products.Count.Should().Be(0);
            _checkoutDomainService.GetCheckout().Total.Should().Be(0);
        }
    }
}
