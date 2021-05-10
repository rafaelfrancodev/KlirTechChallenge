using System.Linq;
using FluentAssertions;
using Klir.TechChallenge.Domain.Services;
using Klir.TechChallenge.Domain.ValueObjects;
using Klir.TechChallenge.Infra.Fakers;
using Xunit;

namespace Klir.TechChallenge.Tests.Domain.Services
{
    public class ProductPromotionDomainServiceTest
    {

        private ProductPromotionDomainService _productPromotionDomainService;
        public ProductPromotionDomainServiceTest()
        {
            _productPromotionDomainService = new ProductPromotionDomainService();
        }

        [Fact]
        public void ShouldNotApplyRulesWhenThereIsNoPromotion()
        {
            //arr
            var quantity = 1;
            var productsPromotion = ProductPromotionFaker.CreateList();
            var productsPromotionVo = productsPromotion.Select(x =>
                new ProductWithPromotionVo(x.Product.Id, x.Product.Name, x.Product.Price, null));
            var productPromotionWithPromotionVo = productsPromotionVo.FirstOrDefault();

            //act
            var result = _productPromotionDomainService.ApplyRules(quantity, productPromotionWithPromotionVo);

            //assert
            result.Should().Be(productPromotionWithPromotionVo.Price);
        }

        /**
         * 1 item should be price = 4 euros
         * 2 items should be price = 8 euros
         * 3 items should be price = 10 euros
         * 4 items should be price = 14 euros
         * 5 items should be price = 18 euros
         * 6 items should be price = 20 euros
         * 7 items should be price = 24 euros
         * 8 items should be price = 28 euros
         * 9 items should be price = 30 euros
         */
        [Theory]
        [InlineData(1, 4)]
        [InlineData(2, 8)]
        [InlineData(3, 10)]
        [InlineData(4, 14)]
        [InlineData(5, 18)]
        [InlineData(6, 20)]
        [InlineData(7, 24)]
        [InlineData(8, 28)]
        [InlineData(9, 30)]
        public void ShouldApplyRulesForRuleThreeForTenEuro(int quantity, decimal priceAssert)
        {
            //arr
            var productsPromotion = ProductPromotionFaker.CreateList();
            var productsPromotionVo = productsPromotion.Select(x =>
                new ProductWithPromotionVo(x.Product.Id, x.Product.Name, x.Product.Price, x.Promotion));
            var productWithPromotionThreeForTenEuro = productsPromotionVo.LastOrDefault();

            //act
            var result = _productPromotionDomainService.ApplyRules(quantity, productWithPromotionThreeForTenEuro);

            //assert
            result.Should().Be(priceAssert);
        }

        /**
         * 1 item should be price = 20 euros
         * 2 items should be price = 20 euros
         * 3 items should be price = 40 euros
         * 4 items should be price = 40 euros
         * 5 items should be price = 60 euros
         * 6 items should be price = 60 euros
         * 7 items should be price = 80 euros
         * 8 items should be price = 80 euros
         * 9 items should be price = 100 euros
         * 10 items should be price = 100 euros
         */
        [Theory]
        [InlineData(1, 20)]
        [InlineData(2, 20)]
        [InlineData(3, 40)]
        [InlineData(4, 40)]
        [InlineData(5, 60)]
        [InlineData(6, 60)]
        [InlineData(7, 80)]
        [InlineData(8, 80)]
        [InlineData(9, 100)]
        [InlineData(10, 100)]
        public void ShouldApplyRulesForRuleByOneGet1Free(int quantity, decimal priceAssert)
        {
            //arr
            var productsPromotion = ProductPromotionFaker.CreateList();
            var productsPromotionVo = productsPromotion.Select(x =>
                new ProductWithPromotionVo(x.Product.Id, x.Product.Name, x.Product.Price, x.Promotion));
            var productWithPromotionByOneGet1Free = productsPromotionVo.FirstOrDefault();

            //act
            var result = _productPromotionDomainService.ApplyRules(quantity, productWithPromotionByOneGet1Free);

            //assert
            result.Should().Be(priceAssert);
        }
    }
}
