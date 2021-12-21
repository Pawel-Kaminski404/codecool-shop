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
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public IProductService ProductService { get; set; }
        public IConfiguration Configuration { get; }

        private readonly ISupplierDao _supplierDao;
        private readonly IProductCategoryDao _productCategoryDao;

        public ProductController(ILogger<ProductController> logger, IConfiguration config,
            IProductService productService, ISupplierDao supplierDao, IProductCategoryDao productCategoryDao)
        {
            Configuration = config;
            _logger = logger;
            ProductService = productService;
            _supplierDao = supplierDao;
            _productCategoryDao = productCategoryDao;
        }

        public IActionResult Index()
        {
            var products = ProductService.GetProductsForCategory("All");
            var categories = _productCategoryDao.GetAll();
            var suppliers = _supplierDao.GetAll();
            return View((products.ToList(), categories.ToList(), suppliers.ToList()));
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
