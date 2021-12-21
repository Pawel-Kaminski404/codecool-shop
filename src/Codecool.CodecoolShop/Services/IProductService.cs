using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Services
{
    public interface IProductService
    {
        ProductCategory GetProductCategory(int categoryId);
        IEnumerable<Product> GetProductsForCategory(int categoryId);
        IEnumerable<Product> GetProductsForSupplier(int supplierId);
    }
}