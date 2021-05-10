using System.Linq;
using FluentAssertions;
using Klir.TechChallenge.Domain.Entities;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Interfaces.Repositories;
using Klir.TechChallenge.Domain.Services;
using Klir.TechChallenge.Domain.ValueObjects;
using Klir.TechChallenge.Infra.Fakers;
using Moq;
using Xunit;

namespace Klir.TechChallenge.Tests.Domain.Services
{
    public class CheckoutDomainServiceTest
    {
        private CheckoutDomainService _checkoutDomainService;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IProductPromotionDomainService> _productPromotionDomainServiceMock;

        public CheckoutDomainServiceTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productPromotionDomainServiceMock = new Mock<IProductPromotionDomainService>();
            _checkoutDomainService = new  CheckoutDomainService(_productRepositoryMock.Object, _productPromotionDomainServiceMock.Object);
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
            var productsPromotion = ProductPromotionFaker.CreateList();
            var productsPromotionVo = productsPromotion.Select(x =>
                new ProductWithPromotionVo(x.Product.Id, x.Product.Name, x.Product.Price, x.Promotion));
            _productPromotionDomainServiceMock
                .Setup(x => x.ApplyRules(It.IsAny<int>(), It.IsAny<ProductWithPromotionVo>())).Returns(20);
            _productRepositoryMock.Setup(x => x.GetWithPromotion()).Returns(productsPromotionVo);

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
            var productsPromotion = ProductPromotionFaker.CreateList();
            var productsPromotionVo = productsPromotion.Select(x =>
                new ProductWithPromotionVo(x.Product.Id, x.Product.Name, x.Product.Price, x.Promotion));
            _productPromotionDomainServiceMock
                .Setup(x => x.ApplyRules(It.IsAny<int>(), It.IsAny<ProductWithPromotionVo>())).Returns(40);
            _productRepositoryMock.Setup(x => x.GetWithPromotion()).Returns(productsPromotionVo);
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
        public void ShouldRemoveCartItemCheckoutWhenExistsProductInShoppingCartItem()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.CreateWithProducts();
            var shoppingCartItem = shoppingCartItems.Products.FirstOrDefault();
            var productsPromotion = ProductPromotionFaker.CreateList();
            var productsPromotionVo = productsPromotion.Select(x =>
                new ProductWithPromotionVo(x.Product.Id, x.Product.Name, x.Product.Price, x.Promotion));
            _productPromotionDomainServiceMock
                .Setup(x => x.ApplyRules(It.IsAny<int>(), It.IsAny<ProductWithPromotionVo>())).Returns(40);
            _productRepositoryMock.Setup(x => x.GetWithPromotion()).Returns(productsPromotionVo);
            _checkoutDomainService.AddCartItem(shoppingCartItem);

            //act
            _checkoutDomainService.RemoveCartItem(shoppingCartItem.Product.Id);

            //asset
            _checkoutDomainService.GetCheckout().Products.Count.Should().Be(0);
            _checkoutDomainService.GetCheckout().Total.Should().Be(0);
        }

        [Fact]
        public void ShouldNotRemoveCartItemCheckoutWhenDoesntExistsProductInShoppingCartItem()
        {

            //act
            _checkoutDomainService.RemoveCartItem(30);

            //asset
            _checkoutDomainService.GetCheckout().Products.Count.Should().Be(0);
            _checkoutDomainService.GetCheckout().Total.Should().Be(0);
        }


        [Fact]
        public void ShouldAddCartItemCheckoutWhenDoesntExistsProductInShoppingCartItemAndProductDoesntPromotion()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.CreateWithProducts();
            var productsPromotion = ProductPromotionFaker.CreateList();
            var productsPromotionVo = productsPromotion.Select(x =>
                new ProductWithPromotionVo(x.Product.Id, x.Product.Name, x.Product.Price, null));
            _productPromotionDomainServiceMock
                .Setup(x => x.ApplyRules(It.IsAny<int>(), It.IsAny<ProductWithPromotionVo>())).Returns(20);
            _productRepositoryMock.Setup(x => x.GetWithPromotion()).Returns(productsPromotionVo);

            //act
            _checkoutDomainService.AddCartItem(shoppingCartItems.Products.FirstOrDefault());

            //asset
            _checkoutDomainService.GetCheckout().Products.Count.Should().Be(1);
            _checkoutDomainService.GetCheckout().Products.FirstOrDefault().Quantity.Should().Be(1);
            _checkoutDomainService.GetCheckout().Total.Should().Be(20);

        }

        [Fact]
        public void ShouldUpdateCartItemCheckoutWhenDoesExistsProductInShoppingCartItemAndProductDoesntPromotion()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.CreateWithProducts();
            var shoppingCartItem = shoppingCartItems.Products.FirstOrDefault();
            var productsPromotion = ProductPromotionFaker.CreateList();
            var productsPromotionVo = productsPromotion.Select(x =>
                new ProductWithPromotionVo(x.Product.Id, x.Product.Name, x.Product.Price, null));
            _productPromotionDomainServiceMock
                .Setup(x => x.ApplyRules(It.IsAny<int>(), It.IsAny<ProductWithPromotionVo>())).Returns(20);
            _productRepositoryMock.Setup(x => x.GetWithPromotion()).Returns(productsPromotionVo);
            _checkoutDomainService.AddCartItem(shoppingCartItem);

            //act
            shoppingCartItem.SetQuantity(2);
            _checkoutDomainService.AddCartItem(shoppingCartItem);

            //asset
            _checkoutDomainService.GetCheckout().Products.Count.Should().Be(1);
            _checkoutDomainService.GetCheckout().Products.FirstOrDefault().Quantity.Should().Be(2);
            _checkoutDomainService.GetCheckout().Products.FirstOrDefault().Total.Should().Be(20);
            _checkoutDomainService.GetCheckout().Total.Should().Be(20);
        }
    }
}
