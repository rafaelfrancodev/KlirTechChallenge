using FluentAssertions;
using Klir.TechChallenge.Domain.Entities;
using Klir.TechChallenge.Infra.Fakers;
using Xunit;

namespace Klir.TechChallenge.Tests.Domain.Entities
{
    public class ProductPromotionTest
    {
        [Fact]
        public void ShouldCreateProductPromotionInstance()
        {
            //arr
            var product = ProductFaker.Create();
            var promotion = PromotionFaker.CreateBuyTwoGetOneFree();
            var firtInstance = new ProductPromotion(product, promotion);

            //act
            var secondInstance = new ProductPromotion(firtInstance.Product, firtInstance.Promotion);

            //assert
            firtInstance.Should().BeEquivalentTo(secondInstance);
        }
    }
}
