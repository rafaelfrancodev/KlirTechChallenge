using Klir.TechChallenge.Application.ProductAppService.ViewModel;
using System.Collections.Generic;

namespace Klir.TechChallenge.Application.Interfaces
{
    public interface IProductAppService
    {
        IEnumerable<ProductWithPromotionViewModel> GetWithPromotion();
    }
}
