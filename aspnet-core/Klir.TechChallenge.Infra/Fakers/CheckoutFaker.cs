using Klir.TechChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using Klir.TechChallenge.Domain.ValueObjects;

namespace Klir.TechChallenge.Infra.Fakers
{
    public static class CheckoutFaker
    {
        public static Checkout Create()
        {
            return new Checkout(Guid.NewGuid(), new List<ShoppingCartItem>());
        }

        public static Checkout CreateWithProducts()
        {
            var cartId = Guid.NewGuid();
            return new Checkout(cartId, CreateItems(cartId));
        }

        public static List<ShoppingCartItem> CreateItems(Guid cartId)
        {
            var product = ProductFaker.Create();
            var productVO = new ProductWithPromotionVo(product.Id, product.Name, product.Price, null);


            return new List<ShoppingCartItem>(new List<ShoppingCartItem>()
            {
                new ShoppingCartItem(Guid.NewGuid(), cartId, productVO, 1, product.Price)
            });
        }





    }
}
