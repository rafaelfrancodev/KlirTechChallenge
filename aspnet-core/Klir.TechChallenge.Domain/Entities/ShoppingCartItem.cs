using System;

namespace Klir.TechChallenge.Domain.Entities
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public Guid CheckoutId { get; set; }
        public Product Product { get; }
        public int Quantity { get; set; }
        public decimal Price { get; }
        public decimal Total => Price * Quantity;

        public ShoppingCartItem(Guid id, Guid cartId, Product product, int quantity, decimal price)
        {
            Id = id;
            CheckoutId = cartId;
            Product = product;
            Quantity = quantity;
            Price = price;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
