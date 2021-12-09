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

        [ActionName("sendCheckout")]
        public IActionResult SendCheckout([FromForm] string name, [FromForm] string email, [FromForm] string phoneNumber,
            [FromForm] string address, [FromForm] string zipCode, [FromForm] string country, [FromForm] string city)
        {
            Checkout checkout = new Checkout(name, email, phoneNumber, address, zipCode, country, city); 
            _checkoutDao.Add(checkout);
            //_userDao.Get(userId).SetCheckout(checkout);
            
            return RedirectToAction("Index","Payment");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}