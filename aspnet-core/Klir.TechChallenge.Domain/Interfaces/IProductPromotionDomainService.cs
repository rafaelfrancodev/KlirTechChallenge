using Klir.TechChallenge.Domain.ValueObjects;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface IProductPromotionDomainService
    {
        decimal ApplyRules(int quantity, ProductWithPromotionVo productPromotion);
    }
}
