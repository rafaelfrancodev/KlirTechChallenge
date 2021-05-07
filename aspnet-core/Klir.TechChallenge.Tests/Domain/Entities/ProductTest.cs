using FluentAssertions;
using Klir.TechChallenge.Domain.Entities;
using Klir.TechChallenge.Infra.Fakers;
using Xunit;

namespace Klir.TechChallenge.Tests.Domain.Entities
{
    public class ProductTest
    {
        [Fact]
        public void ShouldCreateProductInstance()
        {
            //arr
            var firtInstance = ProductFaker.Create();

            //act
            var secondInstance = new Product(firtInstance.Id, firtInstance.Name, firtInstance.Price, firtInstance.Promotion);

            //assert
            firtInstance.Should().BeEquivalentTo(secondInstance);
        }
    }
}
