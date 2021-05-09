using Klir.TechChallenge.Domain.Entities;
using Klir.TechChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Klir.TechChallenge.Domain.Services
{
    public class CheckoutDomainService : ICheckoutDomainService
    {

        private Checkout _dataCheckout;

        public CheckoutDomainService()
        {
            _dataCheckout = new Checkout(Guid.NewGuid(), new List<ShoppingCartItem>());
        }

        public Checkout GetCheckout()
        {
            return _dataCheckout;
        }


        public Checkout AddCartItem(ShoppingCartItem cartItem)
        {
            var foundProductInCart = _dataCheckout.Products.Where(x => x.Product.Id == cartItem.Product.Id);

            if (!foundProductInCart.Any()) 
            {
                _dataCheckout.Products.Add(new ShoppingCartItem(Guid.NewGuid(), _dataCheckout.Id, cartItem.Product, cartItem.Quantity, cartItem.Product.Price));
            }
            else
            {
                foreach (var x in _dataCheckout.Products.Where(x => x.Product.Id == cartItem.Product.Id))
                {
                    x.SetQuantity(cartItem.Quantity);
                    break;
                }
            }

            return _dataCheckout;
        }

        public Checkout RemoveCartItem(ShoppingCartItem cartItem)
        {
            var foundProductInCart = _dataCheckout.Products.Where(x => x.Product.Id == cartItem.Product.Id);

            if (foundProductInCart.Any())
            {
                var cartItemToRemove = _dataCheckout.Products.SingleOrDefault(x => x.Product.Id == cartItem.Product.Id);
                _dataCheckout.Products.Remove(cartItemToRemove);
            }

            return _dataCheckout;
        }
    }
}
