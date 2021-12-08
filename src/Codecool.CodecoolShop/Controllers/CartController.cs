using System;
using System.Collections.Generic;
using System.Diagnostics;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartControllerTest : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private Cart cart;
        
        [Route("/addProduct")]
        public IActionResult AddToCart([FromQuery] int id, [FromQuery] int userId)
        {
            IEnumerable<Product> listOfExistingProducts = ProductDaoMemory.GetInstance().GetAll();
            IEnumerable<User> listOfExistingUsers = UserDaoMemory.GetInstance().GetAll();
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
            cart.GetListOfProducts().Add(product);
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}