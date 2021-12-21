using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos
{
    public class ProductDaoDb : IProductDao
    {
        private readonly IDbConnectionService _dbConnectionService;
        private readonly IProductCategoryDao _productCategoryDao;
        public ProductDaoDb(IDbConnectionService dbConnectionService, IProductCategoryDao productCategoryDao)  
        {
            _dbConnectionService = dbConnectionService;
            _productCategoryDao = productCategoryDao;
        }

        public void Add(Product item)
        {
            throw new System.NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetBy(Supplier supplier)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetBy(ProductCategory productCategory)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
