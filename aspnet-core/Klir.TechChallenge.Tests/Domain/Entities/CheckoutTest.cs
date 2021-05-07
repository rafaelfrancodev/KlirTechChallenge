using FluentAssertions;
using Klir.TechChallenge.Domain.Entities;
using Klir.TechChallenge.Infra.Fakers;
using Xunit;

namespace Klir.TechChallenge.Tests.Domain.Entities
{
    public class CheckoutTest
    {
        [Fact]
        public void ShouldCreateCartInstance()
        {
            //arr
            var cart = CheckoutFaker.CreateWithProducts();
            var firtInstance = new Checkout(cart.Id, cart.Products); 

            //act
            var secondInstance = new Checkout(firtInstance.Id, firtInstance.Products);

            //assert
            firtInstance.Should().BeEquivalentTo(secondInstance);
        }
    }
}
