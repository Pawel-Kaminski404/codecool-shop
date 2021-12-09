using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class CheckoutDaoMemory : ICheckoutDao
    {
        private List<Checkout> data = new List<Checkout>();
        private static CheckoutDaoMemory instance = null;

        private CheckoutDaoMemory()
        {
        }

        public static CheckoutDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new CheckoutDaoMemory();
            }

            return instance;
        }

        public void Add(Checkout checkout)
        {
            checkout.Id = data.Count + 1;
            data.Add(checkout);
        }

        public void Remove(int id)
        {
            data.Remove(this.Get(id));
        }

        public Checkout Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<Checkout> GetAll()
        {
            return data;
        }
    }
}