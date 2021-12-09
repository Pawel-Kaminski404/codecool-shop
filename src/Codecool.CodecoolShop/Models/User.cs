namespace Codecool.CodecoolShop.Models
{
    public class User : BaseModel
    {
        private string _name;
        private string _email;
        private string _password;
        private Cart _cart;
        private Checkout _checkout;

        public User(string name, string email, string password)
        {
            _name = name;
            _email = email;
            _password = password;
            _cart = new Cart();
            _checkout = null;
        }

        public Cart GetCart()
        {
            return _cart;
        }

        public void SetCheckout(Checkout checkout)
        {
            _checkout = checkout;
        }
    }
}