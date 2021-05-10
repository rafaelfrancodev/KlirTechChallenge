using Klir.TechChallenge.Application.CheckoutAppService.Input;
using Klir.TechChallenge.Application.CheckoutAppService.ViewModel;
using Klir.TechChallenge.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [Route("api/v1/checkout")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutAppService _checkoutAppService;

        public CheckoutController(ICheckoutAppService checkoutAppService)
        {
            _checkoutAppService = checkoutAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CheckoutViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Get()
        {
            return Ok(_checkoutAppService.GetCheckout());
        }

        [HttpPost]
        [ProducesResponseType(typeof(CheckoutViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] ShoppingCartItemInput input)
        {
            var result = _checkoutAppService.AddCartItem(input);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{productId}")]
        [ProducesResponseType(typeof(CheckoutViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromRoute] int productId)
        {
            var result = _checkoutAppService.RemoveCartItem(productId);
            return Ok(result);
        }
    }
}