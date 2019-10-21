using System;
using System.Collections.Generic;
using System.Text;


namespace WebApplication.BLogic.Library
{
    public interface IStoreRepository : IDisposable
    {
        //IEnumerable<Location> GetStore(string search = null);

        //Location GetStoreById(int id);

        void AddOrder(Order order);
        List<Order> GetOrderHistory(int search);
        Dictionary<BLogic.Library.Product, int> GetInventoryByStoreId(int Id);
        //Order GetOrderById(int Id);

        //void AddLocation(Location location);

        public List<Location> GetAllLocations();


        Location GetLocationById(int Id);
        // Location GetLocationByAddress(string search = null);

        void AddCustomer(Customer customer);

        //Customer GetCustomerById(int Id);

        List<BLogic.Library.Customer> GetCustomer(string FirstName, string LastName);
        List<Customer> GetCustomerByName(string name);
        void UpdateInventory(InventoryItem inventoryItem);

        void Save();

        //void Save();
    }
}
