using Klir.TechChallenge.Application.CheckoutAppService.Input;
using Klir.TechChallenge.Application.CheckoutAppService.Mappers;
using Klir.TechChallenge.Application.CheckoutAppService.ViewModel;
using Klir.TechChallenge.Application.Interfaces;
using Klir.TechChallenge.Domain.Interfaces;

namespace Klir.TechChallenge.Application.CheckoutAppService
{
    public class CheckoutAppService : ICheckoutAppService
    {
        private readonly ICheckoutDomainService _checkoutDomainService;

        public CheckoutAppService(ICheckoutDomainService checkoutDomainService)
        {
            _checkoutDomainService = checkoutDomainService;
        }
        
        public CheckoutViewModel AddCartItem(ShoppingCartItemInput cartItem)
        {
            var entity = _checkoutDomainService.AddCartItem(cartItem.MapperShoppingCartInputToDomain());
            return entity.MapperCheckoutDomainToViewModel();
        }

        public CheckoutViewModel RemoveCartItem(ShoppingCartItemInput cartItem)
        {
            var entity = _checkoutDomainService.RemoveCartItem(cartItem.MapperShoppingCartInputToDomain());
            return entity.MapperCheckoutDomainToViewModel();
        }

        public CheckoutViewModel GetCheckout()
        {
            return _checkoutDomainService.GetCheckout().MapperCheckoutDomainToViewModel();
        }
    }
}
