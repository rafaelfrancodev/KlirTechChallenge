﻿using System.Linq;
using FluentAssertions;
using Klir.TechChallenge.Domain.Entities;
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

        public CheckoutDomainServiceTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _checkoutDomainService = new  CheckoutDomainService(_productRepositoryMock.Object);
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
        public void ShouldRemoveCartItemCheckoutWhenDoesExistsProductInShoppingCartItem()
        {
            //arr
            var shoppingCartItems = CheckoutFaker.CreateWithProducts();
            var shoppingCartItem = shoppingCartItems.Products.FirstOrDefault();
            _checkoutDomainService.AddCartItem(shoppingCartItem);

            //act
            _checkoutDomainService.RemoveCartItem(shoppingCartItem.Product.Id);

            //asset
            _checkoutDomainService.GetCheckout().Products.Count.Should().Be(0);
            _checkoutDomainService.GetCheckout().Total.Should().Be(0);
        }
    }
}
