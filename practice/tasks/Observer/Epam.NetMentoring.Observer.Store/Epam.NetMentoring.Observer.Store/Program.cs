using System;

//IT: ?????????

namespace Epam.NetMentoring.Observer.Store
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();
            var customer1 = new Customer("Customer1");
            var customer2 = new Customer("Customer2");
            var supplier = new Supplier("Suplier");
            store.Subscribe(supplier);
            supplier.DeliveryStore = store;

            store.Subscribe(customer1);
            store.Subscribe(customer2);


            store.SupplyItem(new Item("Product1", 10, 5));

            store.SupplyItem(new Item("Product2", 1, 3));
            store.SupplyItem(new Item("Product2", 3, 3));

            customer1.Buy(store, "Product2", 2);


            //IT: as usual everyone uses ReadKey(), but ReadLine is also OK.
            Console.ReadLine();
        }
    }
}
