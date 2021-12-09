using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class UserDaoMemory : IUserDao
    {
        private List<User> data = new List<User>();
        private static UserDaoMemory instance = null;

        private UserDaoMemory()
        {
        }

        public static UserDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new UserDaoMemory();
            }

            return instance;
        }

        public void Add(User user)
        {
            user.Id = data.Count + 1;
            data.Add(user);
        }

        public void Remove(int id)
        {
            data.Remove(this.Get(id));
        }

        public User Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return data;
        }
    }
}