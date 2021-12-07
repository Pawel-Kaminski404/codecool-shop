using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class Cart : BaseModel
    {
        private List<Product> _listOfProducts = new List<Product>();
        private static Cart instance = null;

        public static Cart GetInstance()
        {
            if (instance == null)
            {
                instance = new Cart();
            }

            return instance;
        }
        
        public List<Product> GetListOfProducts()
        {
            return _listOfProducts;
        }
    }
}