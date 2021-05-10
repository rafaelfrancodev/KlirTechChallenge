using Klir.TechChallenge.Domain.Entities;
using Klir.TechChallenge.Domain.Interfaces;
using Klir.TechChallenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Klir.TechChallenge.Domain.Services
{
    public class CheckoutDomainService : ICheckoutDomainService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductPromotionDomainService _productPromotionDomainService;
        private readonly Checkout _dataCheckout;

        public CheckoutDomainService(IProductRepository productRepository, IProductPromotionDomainService productPromotionDomainService)
        {
            _productRepository = productRepository;
            _productPromotionDomainService = productPromotionDomainService;
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
                    var applyIfHasPromotion = _productPromotionDomainService.ApplyRules(cartItem.Quantity, product);
                    var shoppingCartItem = new ShoppingCartItem(Guid.NewGuid(), _dataCheckout.Id, product, cartItem.Quantity, product.Price);
                    if (shoppingCartItem.Product.Promotion != null)
                    {
                        shoppingCartItem.SetTotalHasPromotion(applyIfHasPromotion);
                    }
                    else
                    {
                        shoppingCartItem.SetTotal();
                    }
                    _dataCheckout.Products.Add(shoppingCartItem);
                }
            }
            else
            {
                foreach (var x in _dataCheckout.Products.Where(x => x.Product.Id == cartItem.Product.Id))
                {
                    x.Product.SetPrice(product.Price);
                    var applyIfHasPromotion = _productPromotionDomainService.ApplyRules(cartItem.Quantity, x.Product);
                    var shoppingCartItem = new ShoppingCartItem(Guid.NewGuid(), _dataCheckout.Id, x.Product, cartItem.Quantity, x.Product.Price);
                    if (shoppingCartItem.Product.Promotion != null)
                    {
                        x.SetTotalHasPromotion(applyIfHasPromotion);
                    }
                    else
                    {
                        x.SetTotal();
                    }
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
