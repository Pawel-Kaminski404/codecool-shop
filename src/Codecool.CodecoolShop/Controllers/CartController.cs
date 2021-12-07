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
        private Cart cart = Cart.GetInstance();
        
        [Route("/addProduct")]
        public IActionResult AddToCart([FromQuery] int id)
        {
            IEnumerable<Product> listOfExistingProducts = ProductDaoMemory.GetInstance().GetAll();
            Product product = null;
            foreach (Product existingProduct in listOfExistingProducts)
            {
                if (existingProduct.Id == id)
                {
                    product = existingProduct;
                }
            }
            cart.GetListOfProducts().Add(product);
            ReadCart(cart.GetListOfProducts());

            return Ok();
        }

        private void ReadCart(List<Product> carts)
        {
            foreach (var product in carts)
            {
                Console.WriteLine(product.Name);
            }

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}