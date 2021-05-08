using Klir.TechChallenge.Domain.ValueObjects;
using System.Collections.Generic;

namespace Klir.TechChallenge.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public IEnumerable<ProductWithPromotionVo> GetWithPromotion();
    }
}
