using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private CartService _cartService = new CartService(ProductDaoMemory.GetInstance(), UserDaoMemory.GetInstance());
        
        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }
        
        [Route("/addProduct")]
        public IActionResult AddToCart([FromQuery] int id, [FromQuery] int userId)
        {
            _cartService.AddToCart(id,userId);
            var cartItems = _cartService.GetCartProducts(userId);
            string json1 = JsonSerializer.Serialize(cartItems.Count);
            string json2 = JsonSerializer.Serialize(id);
            string jsonString = "[" + json1 + "," + json2 + "]";
            return Ok(jsonString);
        }

        [Route("/deleteProduct")]
        public IActionResult DeleteFromCart([FromQuery] int id, [FromQuery] int userId)
        {
            _cartService.DeleteFromCart(id, userId);
            var cartItems = _cartService.GetCartProducts(userId);
            var totalPriceOfItems = _cartService.GetTotalPriceOfCartItems(1);
            string json1 = JsonSerializer.Serialize(cartItems);
            string json2 = JsonSerializer.Serialize(totalPriceOfItems);
            string jsonString = "[" + json1 + "," + json2 + "]";
            return Ok(jsonString);
        }
        
        public IActionResult Cart()
        {
            var cartItems = _cartService.GetCartProducts(1);
            var totalPriceOfItems = _cartService.GetTotalPriceOfCartItems(1);
            ViewBag.CartItems = cartItems;
            ViewBag.totalPriceOfItems = totalPriceOfItems;
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}