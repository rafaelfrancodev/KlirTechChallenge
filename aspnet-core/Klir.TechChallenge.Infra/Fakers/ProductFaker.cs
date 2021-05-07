using Klir.TechChallenge.Domain.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Klir.TechChallenge.Infra.Fakers
{
    [ExcludeFromCodeCoverage]
    public static class ProductFaker
    {
        public static IEnumerable<Product> CreateList()
        {
            return new List<Product>()
            {
                new Product(1, "Product A", 20, PromotionFaker.CreateBuyOneGetOneFree()),
                new Product(2, "Product B", 4, PromotionFaker.CreateThreeForTenEuro()),
                new Product(3, "Product C", 2, null),
                new Product(4, "Product D", 4, null)
            };
        }

        public static Product Create()
        {
            return new Product(1, "Product A", 20, PromotionFaker.CreateBuyOneGetOneFree());
        }
    }
}
