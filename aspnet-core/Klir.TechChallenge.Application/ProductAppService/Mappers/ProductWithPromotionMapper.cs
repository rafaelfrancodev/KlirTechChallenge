using Klir.TechChallenge.Application.ProductAppService.ViewModel;
using Klir.TechChallenge.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Klir.TechChallenge.Application.ProductAppService.Mappers
{
    public static class ProductWithPromotionMapper
    {
        public static IEnumerable<ProductWithPromotionViewModel> MapperValueObjectToViewModel(
            IEnumerable<ProductWithPromotionVo> products)
        {
            return products.Select(x => new ProductWithPromotionViewModel ()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Promotion = x.Promotion
            });
        }
    }
}
