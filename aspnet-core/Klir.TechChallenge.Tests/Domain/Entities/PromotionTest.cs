using FluentAssertions;
using Klir.TechChallenge.Domain.Entities;
using Klir.TechChallenge.Infra.Fakers;
using Xunit;

namespace Klir.TechChallenge.Tests.Domain.Entities
{
    public class PromotionTest
    {
        [Fact]
        public void ShouldCreatePromotiontInstance()
        {
            //arr
            var firtInstance = PromotionFaker.CreateThreeForTenEuro();

            //act
            var secondInstance = new Promotion(firtInstance.Id, firtInstance.Description);

            //assert
            firtInstance.Should().BeEquivalentTo(secondInstance);
        }
    }
}
