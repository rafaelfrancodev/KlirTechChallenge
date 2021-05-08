using FluentAssertions;
using Klir.TechChallenge.Domain.Interfaces.Repositories;
using Klir.TechChallenge.Domain.Services;
using Klir.TechChallenge.Domain.ValueObjects;
using Klir.TechChallenge.Infra.Fakers;
using Moq;
using System.Linq;
using Xunit;

namespace Klir.TechChallenge.Tests.Domain.Services
{
    public class ProductDomainServiceTest
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private ProductDomainService _productDomainService;
        
        public ProductDomainServiceTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productDomainService = new ProductDomainService(_productRepositoryMock.Object);
        }

        [Fact]
        public void ShouldGetProductsWithPromotion()
        {
            //arr
            var products = ProductFaker.CreateList();
            var productsVo = products.Select(x => new ProductWithPromotionVo(x.Id, x.Name, x.Price, null));
            _productRepositoryMock.Setup(x => x.GetWithPromotion()).Returns(productsVo);


            //act
            var result = _productDomainService.GetWithPromotion();

            //assert
            result.Count().Should().Be(productsVo.Count());
            _productRepositoryMock.Verify(x => x.GetWithPromotion(), Times.Once);
        }
    }
}
