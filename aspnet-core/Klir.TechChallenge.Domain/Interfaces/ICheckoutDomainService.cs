using Klir.TechChallenge.Domain.Entities;

namespace Klir.TechChallenge.Domain.Interfaces
{
    public interface ICheckoutDomainService
    {
        Checkout AddCartItem(ShoppingCartItem cartItem);
        Checkout RemoveCartItem(ShoppingCartItem cartItem);
        Checkout GetCheckout();
    }
}
