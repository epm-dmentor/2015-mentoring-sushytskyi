using System;
using System.Runtime.ConstrainedExecution;

namespace Epam.NetMentoring.Observer.Store
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();
            var customer1 = new Customer("Customer1");
            var customer2 = new Customer("Customer2");

            store.Register(customer1);
            store.Register(customer2);

            store.AddProduct("Product1", 10, 5);

            store.AddProduct("Product2", 1, 3);
            store.AddProduct("Product2", 3, 3);

            customer1.Buy("Product2", 2);
            store.AddProduct("Product2", 1, 3);
            customer1.UnRegisterStore();
            store.AddProduct("Product1", 1, 5);

            Console.ReadLine();
        }
    }
}
