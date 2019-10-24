using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using  BL = WebApplication.BLogic.Library;
using data = WebApplication.Data;
using BLogic.Library.Interfaces;


namespace WebApplication.Data
{
    public class CustomerRepository : ICustomerRepo

    {
        private Project1Context context;
        public static Project1Context GetContext()
        {
            string connectionString = SecretConfiguration.ConnectionString;

            DbContextOptions<Project1Context> options = new DbContextOptionsBuilder<Project1Context>()
                .UseSqlServer(connectionString)
                .Options;

            return new Project1Context(options);
        }
        public CustomerRepository(Project1Context context)
        {

            this.context = context;

        }

        public List<BLogic.Library.Customer> GetCustomerByFirstName(string firstname)

              => context.Customer.Select(Mapper.MapCustomer).Where(c => c.FirstName == firstname).ToList();



        public void AddNewCustomer(WebApplication.BLogic.Library.Customer customer)
        {
            Customer Cust = Mapper.MapCustomer(customer);
            context.Add(Cust);
            context.SaveChanges();
        }

        public void AddNewCustomer()
        {
            throw new NotImplementedException();
        }

        public List<WebApplication.BLogic.Library.Customer> GetAllCustomers()
        {
            IQueryable<Data.Customer> customers = context .Customer
                .AsNoTracking();

            return customers.Select(Mapper.MapCustomer).ToList();

        }
        public Customer GetCustomerByFirstName()
        {
            throw new NotImplementedException();
        }

        public List<BL.Order> GetOrdersByCustId(int custId)
        {
            List<BL.Order> orders = context.Orders.Select(Mapper.MapOrders).Where(c => c.CustomerId == custId).ToList();
            return orders;
        }

        public List<BL.Location> GetAllStores()
        {
            IQueryable<Data.Location> stores = context.Location
                .AsNoTracking();

            return stores.Select(Mapper.MapLocation).ToList();

        }

        //public Dictionary<WebApplication.BLogic.Library.Product, int> GetInventoryByStoreId(int storeId)
        //{
        //    using var context = GetContext();
        //    List<Data.Inventory> getInventory = context.Inventory.Where(i => i.LocationId == storeId).ToList();
        //    Dictionary<BL.Product, int> ItemList = new Dictionary<BL.Product, int>();
        //    foreach (Data.Inventory item in getInventory)
        //    {
        //        ItemList.Add(new BL.Product()
        //        {
        //            Id = item.ProductId,
        //            Name = context.Product.Single(p => p.Id == item.ProductID).Name,
        //            Price = context.Product.Single(p => p.Id == item.ProductID).Price,



        //        },
        //            (int)item.Quantity);
        //    }
        //    return ItemList;
        //}
        public Dictionary<BLogic.Library.Product, int> GetInventoryByStoreId(int storeId)
        {
            using var context = GetContext();
            List<Inventory> getInventory = context.Inventory.Where(i => i.LocationId == storeId).ToList();
            Dictionary<BLogic.Library.Product, int> keyValuePairs = new Dictionary<BLogic.Library.Product, int>();
            foreach (Inventory item in getInventory)
            {
                keyValuePairs.Add(new BLogic.Library.Product() { Name = context.Product.Single(p => p.Id == item.ProductId).Name, Price = context.Product.Single(p => p.Id == item.ProductId).Price, Id = item.ProductId }, (int)item.Quantity);
            }
            return keyValuePairs;

        }

        public void AddNewOrder(WebApplication.BLogic.Library.Order _ord)
        {
            Orders Ord = Mapper.MapOrders(_ord); //Take in Order Object and mapp to DB
            context.Add(Ord); // Add to DB
            context.SaveChanges(); //Save DB
        }

        public void UpdateInventory(WebApplication.BLogic.Library.InventoryItem invent)
        {
            Data.Inventory Invent = Mapper.MapInventoryItem(invent); //Takes in InventoryItem object and maps to Db
            context.Update(Invent);
            context.SaveChanges();
        }

        public void UpdateOrderDetails(WebApplication.BLogic.Library.OrderDetails od)
        {
            Data.OrderDetails Od = Mapper.MapOrderDetails(od);
            context.Update(Od);
            context.SaveChanges();
        }
    }
}
