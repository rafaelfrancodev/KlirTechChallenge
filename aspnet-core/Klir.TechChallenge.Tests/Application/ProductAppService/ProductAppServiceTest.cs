using FluentAssertions;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.ValueObjects;
using Klir.TechChallenge.Infra.Fakers;
using Moq;
using System.Linq;
using Xunit;

namespace Klir.TechChallenge.Tests.Application.ProductAppService
{
    public class ProductAppServiceTest
    {
        private readonly Mock<IProductDomainService> _productDomainServiceMock;
        private TechChallenge.Application.ProductAppService.ProductAppService _productAppService;

        public ProductAppServiceTest()
        {
            _productDomainServiceMock = new Mock<IProductDomainService>();
            _productAppService = new TechChallenge.Application.ProductAppService.ProductAppService(_productDomainServiceMock.Object);
        }

        [Fact]
        public void ShouldGetProductsWithPromotion()
        {
            //arr
            var products = ProductFaker.CreateList();
            var productsVo = products.Select(x => new ProductWithPromotionVo(x.Id, x.Name, x.Price, null));
            _productDomainServiceMock.Setup(x => x.GetWithPromotion()).Returns(productsVo);
            
            //act
            var result = _productAppService.GetWithPromotion();

            //assert
            result.Count().Should().Be(productsVo.Count());
            _productDomainServiceMock.Verify(x => x.GetWithPromotion(), Times.Once);
        }
    }
}
