using System;

namespace Klir.TechChallenge.Application.CheckoutAppService.Input
{
    public class ShoppingCartItemInput
    {
        public Guid Id { get; set; }
        public Guid CheckoutId { get; set; }
        public ShoppingCartItemProductInput Product { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartItemInput(Guid id, Guid cartId, ShoppingCartItemProductInput product, int quantity)
        {
            Id = id;
            CheckoutId = cartId;
            Product = product;
            Quantity = quantity;
        }

        public ShoppingCartItemInput()
        {
            
        }
    }
}
