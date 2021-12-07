namespace Codecool.CodecoolShop.Models
{
    public class User : BaseModel
    {
        private string _name;
        private string _email;
        private string _password;
        private Cart _cart;

        public User(string name, string email, string password)
        {
            _name = name;
            _email = email;
            _password = password;
            _cart = new Cart();
        }

        public Cart GetCart()
        {
            return _cart;
        }
    }
}