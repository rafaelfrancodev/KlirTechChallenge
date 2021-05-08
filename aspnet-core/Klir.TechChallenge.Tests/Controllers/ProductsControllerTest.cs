using FluentAssertions;
using Klir.TechChallenge.Application.Interfaces;
using Klir.TechChallenge.Application.ProductAppService.Mappers;
using Klir.TechChallenge.Domain.ValueObjects;
using Klir.TechChallenge.Infra.Fakers;
using Klir.TechChallenge.Web.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using Xunit;

namespace Klir.TechChallenge.Tests.Controllers
{
    public class ProductsControllerTest
    {
        private readonly Mock<IProductAppService> _productAppServiceMock;
        private ProductsController _productsController;

        public ProductsControllerTest()
        {
            _productAppServiceMock = new Mock<IProductAppService>();
            _productsController = new ProductsController(_productAppServiceMock.Object);
        }

        [Fact]
        public void ShouldGetProductsWithPromotion()
        {
            //arr
            var products = ProductFaker.CreateList();
            var productsVo = products.Select(x => new ProductWithPromotionVo(x.Id, x.Name, x.Price, null));
            var productsViewModel = ProductWithPromotionMapper.MapperValueObjectToViewModel(productsVo);
            _productAppServiceMock.Setup(x => x.GetWithPromotion()).Returns(productsViewModel);

            //act
            var result = _productsController.Get();

            //assert
            var okObjectResult = (OkObjectResult)result;
            okObjectResult.StatusCode.Should().Be(200);
            _productAppServiceMock.Verify(x => x.GetWithPromotion(), Times.Once);
        }
    }
}
