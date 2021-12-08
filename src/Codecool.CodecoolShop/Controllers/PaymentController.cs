using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace Codecool.CodecoolShop.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;
        private PaymentService _paymentService = new PaymentService(ProductDaoMemory.GetInstance(), UserDaoMemory.GetInstance());
        private CartService _cartService = new CartService(ProductDaoMemory.GetInstance(), UserDaoMemory.GetInstance());

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index([FromQuery] int userId)
        {
            if (userId == 0)
            {
                return RedirectToAction("ErrorPage");
            }
            Cart cart = _cartService.GetCartByUserId(userId);
            return View(cart.GetListOfProducts());
        }

        public IActionResult ErrorPage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
