namespace Codecool.CodecoolShop.Models
{
    public class Checkout : BaseModel
    {
        public string _name;
        public string _email;
        private string _phoneNumber;
        private string _address;
        private string _zipCode;
        private string _country;
        private string _city;

        public Checkout(string name, string email, string phoneNumber, string address, string zipCode, string country, string city)
        {
            _name = name;
            _email = email;
            _phoneNumber = phoneNumber;
            _address = address;
            _zipCode = zipCode;
            _country = country;
            _city = city;
        }
    }
}