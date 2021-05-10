using System;
using Klir.TechChallenge.Domain.ValueObjects;

namespace Klir.TechChallenge.Domain.Entities
{
    public class ShoppingCartItem
    {
        public Guid Id { get; }
        public Guid CheckoutId { get; }
        public ProductWithPromotionVo Product { get; }
        public int Quantity { get; set; }
        public decimal Price { get; }
        public decimal Total { get; set;  }

        public ShoppingCartItem(Guid id, Guid cartId, ProductWithPromotionVo product, int quantity, decimal price)
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

        public void SetTotal()
        {
            Total = Price * Quantity;
        }

        public void SetTotalHasPromotion(decimal total)
        {
            Total = total;
        }
    }
}
