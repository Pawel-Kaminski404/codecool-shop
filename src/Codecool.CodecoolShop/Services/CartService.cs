using System.Collections.Generic;
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

        public Cart GetCartByUserId(int userId)
        {
            User user = _userDao.Get(userId);
            return user.GetCart();
        }
    }
}