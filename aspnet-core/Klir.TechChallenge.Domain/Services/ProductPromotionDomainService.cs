using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.ValueObjects;
using Klir.TechChallenge.Infra.CrossCutting;

namespace Klir.TechChallenge.Domain.Services
{
    public class ProductPromotionDomainService : IProductPromotionDomainService
    {
        public decimal ApplyRules(int quantity, ProductWithPromotionVo productPromotion)
        {
            productPromotion = new ProductWithPromotionVo(productPromotion.Id, productPromotion.Name, productPromotion.Price, productPromotion.Promotion);
            if (productPromotion.Promotion == null)
            {
                return productPromotion.Price;
            }
            
            var rangeNumbers = RangeNumbers.GetRangeNumbers(quantity, productPromotion.Promotion.MinQuantity);
            var numberOutOfRange =
                RangeNumbers.GetTotalNumbersOutOfRange(quantity, productPromotion.Promotion.MinQuantity);
            
            var threeForTenEuro = ApplyRuleThreeForTenEuro(quantity, productPromotion, rangeNumbers, numberOutOfRange);
            if (threeForTenEuro != null)
                return threeForTenEuro.Price;

            var byOneGet1Free = ApplyRuleByOneGet1Free(quantity, productPromotion, rangeNumbers, numberOutOfRange);
            if (byOneGet1Free != null)
            {
                return byOneGet1Free.Price;
            }
            return productPromotion.Price;
        }

        private ProductWithPromotionVo ApplyRuleThreeForTenEuro(int quantity, ProductWithPromotionVo productPromotion, int rangeNumbers, int numberOutOfRange)
        {
            if (productPromotion.Promotion.Price.HasValue)
            {
                decimal price = 0;
                if (rangeNumbers < 1)
                {
                    price = productPromotion.Price * quantity;
                    productPromotion.SetPrice(price);
                    return productPromotion;
                }

                price = productPromotion.Promotion.Price.Value * rangeNumbers;
                if (numberOutOfRange > 0)
                {
                    price += productPromotion.Price * numberOutOfRange;
                }
                productPromotion.SetPrice(price);
                return productPromotion;
            }
            return default;
        }

        private ProductWithPromotionVo ApplyRuleByOneGet1Free(int quantity, ProductWithPromotionVo productPromotion, int rangeNumbers, int numberOutOfRange)
        {
            if (!productPromotion.Promotion.Price.HasValue)
            {
                decimal price = 0;
                if (rangeNumbers < 1)
                {
                    price = productPromotion.Price;
                    productPromotion.SetPrice(price);
                    return productPromotion;
                }

                price = productPromotion.Price * rangeNumbers;
                if (numberOutOfRange > 0)
                {
                    price += productPromotion.Price;
                }

                productPromotion.SetPrice(price);
                return productPromotion;
            }
            return default;
        }
    }
}
