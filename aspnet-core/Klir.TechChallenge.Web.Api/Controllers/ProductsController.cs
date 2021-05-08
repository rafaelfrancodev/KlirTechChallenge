using Klir.TechChallenge.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            return Ok(_productAppService.GetWithPromotion());
        }
    }
}