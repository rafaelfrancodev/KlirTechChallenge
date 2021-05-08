using System;
using System.Collections.Generic;
using System.Linq;

namespace Klir.TechChallenge.Domain.Entities
{
    public class Checkout
    {
        public Guid Id { get; }
        public IEnumerable<ShoppingCartItem> Products { get; }

        public decimal Total => GetTotal();

        public Checkout(Guid id, IEnumerable<ShoppingCartItem> products)
        {
            Id = id;
            Products = products;    
        }

        public decimal GetTotal()
        {
            return Products.Sum(x => x.Total);
        }
    }
}
