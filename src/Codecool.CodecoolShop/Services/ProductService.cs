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
        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            if (categoryId == 0)
            {
                return GetAllProducts();
            }
            else
            {

                return productDao.GetBy(productCategoryDao.Get(categoryId));
            }
        }

        public IEnumerable<Product> GetProductsForSupplier(int supplierId)
        {
            if (supplierId == 0)
            {
                return GetAllProducts();
            }
            else
            {

                return productDao.GetBy(supplierDao.Get(supplierId));
            }
        }

        private IEnumerable<Product> GetAllProducts()
        {
            return productDao.GetAll();
        }
    }
}
