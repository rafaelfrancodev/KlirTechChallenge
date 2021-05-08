using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Interfaces.Repositories;
using Klir.TechChallenge.Domain.ValueObjects;
using System.Collections.Generic;

namespace Klir.TechChallenge.Domain.Services
{
    public class ProductDomainService: IProductDomainService
    {
        private readonly IProductRepository _productRepository;

        public ProductDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductWithPromotionVo> GetWithPromotion()
        {
            return _productRepository.GetWithPromotion();
        }
    }
}
