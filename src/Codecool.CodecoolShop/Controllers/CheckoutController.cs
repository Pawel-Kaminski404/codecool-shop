using System;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Controllers
{
    public class CheckoutController : Controller
    {
        // GET
        private ICheckoutDao _checkoutDao = CheckoutDaoMemory.GetInstance();
        private IUserDao _userDao = UserDaoMemory.GetInstance();

        private readonly ILogger<PaymentController> _logger;

        public CheckoutController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SendCheckout([FromBody] Checkout checkout)
        {
            if (checkout.Validate())
            {
                _logger.LogInformation("Checkout validatation successull.");
                _checkoutDao.Add(checkout);
                _userDao.Get(1).SetCheckout(checkout);
                return Ok();
            }
            _logger.LogInformation("Checkout validatation unsuccessull.");
            return Unauthorized();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}