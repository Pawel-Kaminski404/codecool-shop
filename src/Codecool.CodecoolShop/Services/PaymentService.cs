using Codecool.CodecoolShop.Daos;

namespace Codecool.CodecoolShop.Services
{
    public class PaymentService
    {
        private readonly IProductDao _productDao;
        private readonly IUserDao _userDao;

        public PaymentService(IProductDao productDao, IUserDao userDao)
        {
            _productDao = productDao;
            _userDao = userDao;
        }
    }
}
