using Klir.TechChallenge.Domain.ValueObjects;
using System.Collections.Generic;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IProductDomainService
    {
        IEnumerable<ProductWithPromotionVo> GetWithPromotion();
    }
}
