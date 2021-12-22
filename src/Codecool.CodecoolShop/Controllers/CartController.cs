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
        private readonly ICartService _cartService;

        public CartController(ILogger<CartController> logger, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }
        
        [HttpGet("/addProduct")]
        public IActionResult AddToCart([FromQuery] int id, [FromQuery] int userId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            _cartService.AddToCart(id,userId);
            var cartItems = _cartService.GetCartProducts(userId);
            string json1 = JsonSerializer.Serialize(cartItems.Count);
            string json2 = JsonSerializer.Serialize(id);
            ViewBag.ItemsInCartCounter = cartItems.Count;
            string jsonString = "[" + json1 + "," + json2 + "]";
            return Ok(jsonString);
        }

        [HttpGet("/GetCartAmount")]
        public IActionResult GetCartAmount(int userId)
        {
            var itemsCount = _cartService.GetCartProducts(1).Count;
            string jsonString = JsonSerializer.Serialize(itemsCount);
            return Ok(jsonString);

        }

        [HttpGet("/deleteProduct")]
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