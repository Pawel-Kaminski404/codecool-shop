using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;
        private readonly ISupplierDao supplierDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
            this.supplierDao = supplierDao;
        }

        public ProductCategory GetProductCategory(int categoryId)
        {
            return this.productCategoryDao.Get(categoryId);
        }

        public IEnumerable<Product> GetProductsForCategory(string categoryName)
        {
            Categories category = (Categories)Enum.Parse(typeof(Categories), categoryName);
            int categoriyNumber = (int)category;
            if (categoriyNumber == 0)
            {
                return productDao.GetAll();
            }
            return GetProductsForCategory(categoriyNumber);
        }

        public IEnumerable<Product> GetProductsForSupplier(string supplierName)
        {
            Suppliers supplier = (Suppliers)Enum.Parse(typeof(Suppliers), supplierName);
            int categoriyNumber = (int)supplier;
            if (categoriyNumber == 0)
            {
                return GetAllProducts();
            }
            return GetProductsForSupplier(categoriyNumber);
        }
        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            ProductCategory category = this.productCategoryDao.Get(categoryId);
            if (category.Name == "All")
            {
                return productDao.GetAll();
            }
            else
            {
                return this.productDao.GetBy(category);
            }
        }

        public IEnumerable<Product> GetProductsForSupplier(int supplierId)
        {
            Supplier supplier = supplierDao.Get(supplierId);
            return this.productDao.GetBy(supplier);
        }

        private IEnumerable<Product> GetAllProducts()
        {
            return productDao.GetAll();
        }
        private enum Categories
        {
            All,
            Tablet,
            Laptop
        }

        private enum Suppliers
        {
            All,
            Amazon,
            Lenovo
        }
    }
}
