using Klir.TechChallenge.Domain.Interfaces.Repositories;
using Klir.TechChallenge.Domain.ValueObjects;
using Klir.TechChallenge.Infra.Fakers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Klir.TechChallenge.Infra.Repository
{
    [ExcludeFromCodeCoverage]
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<ProductWithPromotionVo> GetWithPromotion()
        {
            var productsPromotion = ProductPromotionFaker.CreateList();
            var products = ProductFaker.CreateList();
            var query = from prods in products
                        join prodsPromotion in productsPromotion on prods.Id equals prodsPromotion.Product.Id into prodsPromotionDefault
                        from prodsPromotion in prodsPromotionDefault.DefaultIfEmpty()
                        select new ProductWithPromotionVo(prods.Id, prods.Name, prods.Price, prodsPromotion?.Promotion);
            return query.ToList();
        }
    }
}
