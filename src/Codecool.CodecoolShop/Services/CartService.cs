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
            Cart cart = null;
            IEnumerable<Product> listOfExistingProducts = _productDao.GetAll();
            IEnumerable<User> listOfExistingUsers = _userDao.GetAll();
            Product product = null;
            
            foreach (User existingUser in listOfExistingUsers)
            {
                if (existingUser.Id == userId)
                {
                    cart = existingUser.GetCart();
                }
            }
            
            foreach (Product existingProduct in listOfExistingProducts)
            {
                if (existingProduct.Id == id)
                {
                    product = existingProduct;
                }
            }

            if (cart != null) cart.GetListOfProducts().Add(product);
        }
    }

}