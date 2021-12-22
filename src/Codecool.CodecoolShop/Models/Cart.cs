using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class Cart : BaseModel
    {
        private List<Product> _listOfProducts = new List<Product>();
        
        
        public List<Product> GetListOfProducts()
        {
            return _listOfProducts;
        }

        public int GetProductsAmountInCart()
        {
            return _listOfProducts.Count;
        }
    }
}