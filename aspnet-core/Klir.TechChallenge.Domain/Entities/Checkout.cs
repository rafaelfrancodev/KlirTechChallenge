using System;
using System.Collections.Generic;

namespace Klir.TechChallenge.Domain.Entities
{
    public class Checkout
    {
        public Guid Id { get; }
        public IEnumerable<ShoppingCartItem> Products { get; }

        public Checkout(Guid id, IEnumerable<ShoppingCartItem> products)
        {
            Id = id;
            Products = products;    
        }
    }
}
