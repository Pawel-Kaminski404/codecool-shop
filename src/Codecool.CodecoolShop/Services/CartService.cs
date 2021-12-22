using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class CartService
    {
        private readonly IProductDao _productDao;
        private readonly IUserDao _userDao;

        public CartService(IProductDao productDao, IUserDao userDao)
        {
            _productDao = productDao;
            _userDao = userDao;
        }

        public void AddToCart(int id, int userId)
        {
            Product product = _productDao.Get(id);
            User user = _userDao.Get(userId);
            Cart cart = user.GetCart();
            cart.GetListOfProducts().Add(product);
        }
        public List<Product> GetCartProducts(int userId)
        {
            var user = _userDao.Get(userId);
            var cartItems = user.GetCart().GetListOfProducts();
            return cartItems;
        }

        public decimal GetTotalPriceOfCartItems(int userId)
        {
            var user = _userDao.Get(userId);
            var cartItems = user.GetCart().GetListOfProducts();

            return cartItems.Sum(element => element.DefaultPrice);
        }

        public void DeleteFromCart(int id, int userId)
        {
            var user = _userDao.Get(userId);
            var cartItems = user.GetCart().GetListOfProducts();
            foreach (var element in cartItems.Where(element => id == element.Id))
            {
                cartItems.Remove(element);
                Console.WriteLine(1);
                break;
            }
        }
        public Cart GetCartByUserId(int userId)
        {
            User user = _userDao.Get(userId);
            if (user == null)
            {
                return null;
            }
            return user.GetCart();
        }
    }
}