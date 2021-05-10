using Klir.TechChallenge.Domain.Entities;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Klir.TechChallenge.Domain.Services
{
    public class CheckoutDomainService : ICheckoutDomainService
    {
        private readonly IProductRepository _productRepository;
        private readonly Checkout _dataCheckout;

        public CheckoutDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _dataCheckout = new Checkout(Guid.NewGuid(), new List<ShoppingCartItem>());
        }

        public Checkout GetCheckout()
        {
            return _dataCheckout;
        }


        public Checkout AddCartItem(ShoppingCartItem cartItem)
        {
            var foundProductInCart = _dataCheckout.Products.Where(x => x.Product.Id == cartItem.Product.Id);

            var product = _productRepository.GetWithPromotion().FirstOrDefault(x => x.Id == cartItem.Product.Id);

            if (!foundProductInCart.Any())
            {
                if (product != null)
                {
                    cartItem.Product.SetPrice(product.Price);
                    _dataCheckout.Products.Add(new ShoppingCartItem(Guid.NewGuid(), _dataCheckout.Id, cartItem.Product,
                        cartItem.Quantity, product.Price));
                }
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

        public Checkout RemoveCartItem(int productId)
        {
            var foundProductInCart = _dataCheckout.Products.Where(x => x.Product.Id == productId);

            if (foundProductInCart.Any())
            {
                var cartItemToRemove = _dataCheckout.Products.SingleOrDefault(x => x.Product.Id == productId);
                _dataCheckout.Products.Remove(cartItemToRemove);
            }

            return _dataCheckout;
        }
    }
}
