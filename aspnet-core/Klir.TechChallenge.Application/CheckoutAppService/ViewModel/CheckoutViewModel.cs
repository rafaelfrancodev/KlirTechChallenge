using Klir.TechChallenge.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Klir.TechChallenge.Application.CheckoutAppService.ViewModel
{
    public class CheckoutViewModel
    {
        public Guid Id { get; }
        public List<ShoppingCartItem> Products { get; }
        public decimal Total { get; }
        public CheckoutViewModel(Guid id, List<ShoppingCartItem> products, decimal total)
        {
            Id = id;
            Products = products;
            Total = total;  
        }
    }
}
