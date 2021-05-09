using Klir.TechChallenge.Domain.Entities;
using System;

namespace Klir.TechChallenge.Application.CheckoutAppService.Input
{
    public class ShoppingCartItemInput
    {
        public Guid Id { get; set; }
        public Guid CheckoutId { get; set; }
        public Product Product { get; }
        public int Quantity { get; set; }
        public decimal Price { get; }

        public ShoppingCartItemInput(Guid id, Guid cartId, Product product, int quantity, decimal price)
        {
            Id = id;
            CheckoutId = cartId;
            Product = product;
            Quantity = quantity;
            Price = price;
        }
    }
}
