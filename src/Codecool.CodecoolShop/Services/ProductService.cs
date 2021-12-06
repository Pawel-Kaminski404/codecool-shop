using System;
using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
        }

        public ProductCategory GetProductCategory(int categoryId)
        {
            return this.productCategoryDao.Get(categoryId);
        }

        public IEnumerable<Product> GetProductsForCategory(string categoryName)
        {
            Categories category = (Categories)Enum.Parse(typeof(Categories), categoryName);
            int categoriyNumber = (int)category;
            return GetProductsForCategory(categoriyNumber + 1);
        }
        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            ProductCategory category = this.productCategoryDao.Get(categoryId);
            return this.productDao.GetBy(category);
        }
        private enum Categories
        {
            Tablet,
            Laptop
        }
    }
}
