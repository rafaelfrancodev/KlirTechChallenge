using Klir.TechChallenge.Application.Interfaces;
using Klir.TechChallenge.Application.ProductAppService.Mappers;
using Klir.TechChallenge.Application.ProductAppService.ViewModel;
using Klir.TechChallenge.Domain.Interfaces;
using System.Collections.Generic;

namespace Klir.TechChallenge.Application.ProductAppService
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductDomainService _productDomainService;

        public ProductAppService(IProductDomainService productDomainService)
        {
            _productDomainService = productDomainService;
        }
        public IEnumerable<ProductWithPromotionViewModel> GetWithPromotion()
        {
            var products = _productDomainService.GetWithPromotion();
            return ProductWithPromotionMapper.MapperValueObjectToViewModel(products);
        }
    }
}
