using FluentAssertions;
using Klir.TechChallenge.Domain.ValueObjects;
using Klir.TechChallenge.Infra.Fakers;
using Xunit;

namespace Klir.TechChallenge.Tests.Domain.ValueObjects
{
    public class ProductWithPromotionVoTest
    {
        [Fact]
        public void ShouldProductWithPromotionVoInstance()
        {
            //arr
            var product = ProductFaker.Create();
            var promotion = PromotionFaker.CreateBuyTwoGetOneFree();
            var firstIntance = new ProductWithPromotionVo(product.Id, product.Name, product.Price, promotion);

            //act
            var secondInstance = new ProductWithPromotionVo(firstIntance.Id, firstIntance.Name, firstIntance.Price, firstIntance.Promotion);

            //assert
            firstIntance.Should().BeEquivalentTo(secondInstance);
        }
    }
}
