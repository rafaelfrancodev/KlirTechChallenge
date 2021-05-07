using Klir.TechChallenge.Domain.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Klir.TechChallenge.Infra.Fakers
{
    [ExcludeFromCodeCoverage]
    public static class ProductPromotionFaker
    {
        public static IEnumerable<ProductPromotion> CreateList()
        {

            return new List<ProductPromotion>()
            {
                new ProductPromotion(new Product(1, "Product A", 20),
                    PromotionFaker.CreateBuyTwoGetOneFree()),

                new ProductPromotion(new Product(2, "Product B", 4),
                    PromotionFaker.CreateThreeForTenEuro()),
            };
        }
    }
}
