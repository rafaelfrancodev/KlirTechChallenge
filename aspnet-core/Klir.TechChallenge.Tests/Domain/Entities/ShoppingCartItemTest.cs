using FluentAssertions;
using Klir.TechChallenge.Domain.Entities;
using Klir.TechChallenge.Infra.Fakers;
using System;
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
            var firtInstance = new ShoppingCartItem(Guid.NewGuid(), cart.Id, product, 1, product.Price); 

            //act
            var secondInstance = new ShoppingCartItem(firtInstance.Id, firtInstance.CheckoutId, firtInstance.Product, firtInstance.Quantity, firtInstance.Price);

            //assert
            firtInstance.Should().BeEquivalentTo(secondInstance);
        }
    }
}
