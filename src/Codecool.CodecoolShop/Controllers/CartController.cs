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
        private CartService _cartService = new CartService(ProductDaoMemory.GetInstance(), UserDaoMemory.GetInstance());
        
        [Route("/addProduct")]
        public IActionResult AddToCart([FromQuery] int id, [FromQuery] int userId)
        {
            _cartService.AddToCart(id,userId);
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}