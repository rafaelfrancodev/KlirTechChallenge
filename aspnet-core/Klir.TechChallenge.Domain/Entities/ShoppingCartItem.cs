using System;

namespace Klir.TechChallenge.Domain.Entities
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public Guid CheckoutId { get; set; }
        public Product Product { get; }
        public int Quantity { get; }
        public decimal Price { get; }
        public decimal Total { get; }

        public ShoppingCartItem(Guid id, Guid cartId, Product product, int quantity, decimal price)
        {
            Id = id;
            CheckoutId = cartId;
            Product = product;
            Quantity = quantity;
            Price = price;
            Total = price * quantity;  
        }
    }
}
