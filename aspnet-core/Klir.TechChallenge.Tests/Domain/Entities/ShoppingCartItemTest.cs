using FluentAssertions;
using Klir.TechChallenge.Domain.Entities;
using Klir.TechChallenge.Infra.Fakers;
using System;
using Klir.TechChallenge.Domain.ValueObjects;
using Xunit;

namespace Klir.TechChallenge.Tests.Domain.Entities
{
    public class ShoppingCartItemTest
    {
        [Fact]
        public void ShouldCreateCartItemInstance()
        {
            //arr
            var product = ProductFaker.Create();
            var cart = CheckoutFaker.Create();
            var productVO = new ProductWithPromotionVo(product.Id, product.Name, product.Price, null);
            var firtInstance = new ShoppingCartItem(Guid.NewGuid(), cart.Id, productVO, 1, product.Price); 

            //act
            var secondInstance = new ShoppingCartItem(firtInstance.Id, firtInstance.CheckoutId, firtInstance.Product, firtInstance.Quantity, firtInstance.Price);

            //assert
            firtInstance.Should().BeEquivalentTo(secondInstance);
        }
    }
}
