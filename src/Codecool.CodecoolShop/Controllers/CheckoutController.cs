using System;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class CheckoutController : Controller
    {
        // GET
        private ICheckoutDao _checkoutDao = CheckoutDaoMemory.GetInstance();
        private IUserDao _userDao = UserDaoMemory.GetInstance();

        [HttpPost]
        public IActionResult SendCheckout([FromBody] Checkout checkout)
        {
            if (checkout.Validate())
            {
                _checkoutDao.Add(checkout);
                _userDao.Get(1).SetCheckout(checkout);
                return Ok();
            }

            return Unauthorized();
            // return RedirectToAction("Index","Payment");

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}