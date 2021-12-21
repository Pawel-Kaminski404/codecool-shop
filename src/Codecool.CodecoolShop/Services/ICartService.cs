using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Services
{
    public interface ICartService
    {
        void AddToCart(int id, int userId);
        void DeleteFromCart(int id, int userId);
        Cart GetCartByUserId(int userId);
        List<Product> GetCartProducts(int userId);
        decimal GetTotalPriceOfCartItems(int userId);
    }
}