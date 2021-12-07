using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
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
            if (categoriyNumber == 0)
            {
                return GetAllProducts();
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
            return this.productDao.GetBy(category);
        }

        public IEnumerable<Product> GetProductsForSupplier(int supplierId)
        {
            Supplier supplier = SupplierDaoMemory.GetInstance().Get(supplierId);
            return this.productDao.GetBy(supplier);
        }

        private IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> output = GetProductsForCategory(1);
            var values = Enum.GetValues(typeof(Categories));
            foreach (var item in values)
            {
                if ((int)item != 0 && (int)item != 1)
                {
                    output = output.Concat(GetProductsForCategory((int)item));
                }
            }
            return output;
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
