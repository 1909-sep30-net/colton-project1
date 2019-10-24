using System;
using System.Collections.Generic;
using System.Text;
using BLogic.Library;

namespace BLogic.Library.Interfaces
{
    public interface ICustomerRepo
    {
        public void AddNewCustomer(WebApplication.BLogic.Library.Customer customer);

        public List<WebApplication.BLogic.Library.Customer> GetAllCustomers();

        public List<WebApplication.BLogic.Library.Customer> GetCustomerByFirstName(string customer);


        public List<WebApplication.BLogic.Library.Order> GetOrdersByCustId(int custId);

        // public Order PlaceOrder(int id);

        public List<WebApplication.BLogic.Library.Location> GetAllStores();

        public Dictionary<WebApplication.BLogic.Library.Product, int> GetInventoryByStoreId(int storeId);

        public void AddNewOrder(WebApplication.BLogic.Library.Order _ord);

        public void UpdateInventory(WebApplication.BLogic.Library.InventoryItem invent);

        public void UpdateOrderDetails(WebApplication.BLogic.Library.OrderDetails od);
    }
}
