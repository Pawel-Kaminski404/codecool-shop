using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using System.Text.Json;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance());
        }

        public IActionResult Index()
        {
            var products = ProductService.GetProductsForCategory("All");
            return View(products.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/getProducts")]
        public IActionResult GetProducts([FromQuery] string filterBy, [FromQuery] string filter)
        {
            IEnumerable<Product> products;
            if (filterBy == "category")
            {
                products = ProductService.GetProductsForCategory(filter);
            }
            else
            {
                products = ProductService.GetProductsForSupplier(filter);
            }
            string jsonString = JsonSerializer.Serialize(products);
            return Ok(jsonString);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
