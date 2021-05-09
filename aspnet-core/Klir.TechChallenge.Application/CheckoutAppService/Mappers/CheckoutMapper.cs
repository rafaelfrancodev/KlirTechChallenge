using Klir.TechChallenge.Application.CheckoutAppService.Input;
using Klir.TechChallenge.Application.CheckoutAppService.ViewModel;
using Klir.TechChallenge.Domain.Entities;

namespace Klir.TechChallenge.Application.CheckoutAppService.Mappers
{
    public static class CheckoutMapper
    {
        public static ShoppingCartItem MapperShoppingCartInputToDomain(this ShoppingCartItemInput input)
        {
            return new ShoppingCartItem(input.Id, input.CheckoutId, input.Product, input.Quantity, input.Price);
        }

        public static CheckoutViewModel MapperCheckoutDomainToViewModel(this Checkout checkout)
        {
            return  new CheckoutViewModel(checkout.Id, checkout.Products, checkout.Total);
        }
    }
}
