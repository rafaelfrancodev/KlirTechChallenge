using Klir.TechChallenge.Application.CheckoutAppService.Input;
using Klir.TechChallenge.Application.CheckoutAppService.ViewModel;

namespace Klir.TechChallenge.Application.Interfaces
{
    public interface ICheckoutAppService
    {
        CheckoutViewModel AddCartItem(ShoppingCartItemInput cartItem);
        CheckoutViewModel RemoveCartItem(ShoppingCartItemInput cartItem);
        CheckoutViewModel GetCheckout();
    }
}
