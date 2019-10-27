﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using  BL = WebApplication.BLogic.Library;
using data = WebApplication.Data.Entitis;
using BLogic.Library.Interfaces;
using BLogic.Library;


namespace WebApplication.Data
{
    public class CustomerRepository : ICustomerRepo

    {
        private data.Project1Context context;
        public static data.Project1Context GetContext()
        {
            string connectionString = SecretConfiguration.ConnectionString;

            DbContextOptions<data.Project1Context> options = new DbContextOptionsBuilder<data.Project1Context>()
                .UseSqlServer(connectionString)
                .Options;

            return new data.Project1Context(options);
        }
        public CustomerRepository(data.Project1Context context)
        {

            this.context = context;

        }

        public List<BLogic.Library.Customer> GetCustomerByFirstName(string firstname)

              => context.Customers.Select(Mapper.MapCustomer).Where(c => c.FirstName == firstname).ToList();



        public void AddNewCustomer(WebApplication.BLogic.Library.Customer customer)
        {
            data.Customers Cust = Mapper.MapCustomer(customer);
            context.Add(Cust);
            context.SaveChanges();
        }

        public void AddNewCustomer()
        {
            throw new NotImplementedException();
        }

        public List<WebApplication.BLogic.Library.Customer> GetAllCustomers()
        {
            IQueryable<data.Customers> customers = context.Customers
                .AsNoTracking();

            return customers.Select(Mapper.MapCustomer).ToList();

        }   
        public BL.Customer GetCustomerByFirstName()
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
            IQueryable<data.Location> stores = context.Location
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
            //using var context = GetContext();
            //List<data.Inventory> getInventory = context.Inventory.Where(i => i.LocationId == storeId).ToList();
            //Dictionary<BLogic.Library.Product, int> keyValuePairs = new Dictionary<BLogic.Library.Product, int>();
            //foreach (data.Inventory item in getInventory)
            //{
            //    keyValuePairs.Add(new BLogic.Library.Product() { Name = context.Products.Single(p => p.ProductId == item.ProductId).Name, Price = context.Products.Single(p => p.ProductId == item.ProductId).Price, Id = item.ProductId }, (int)item.Quantity);
            //}
            //return keyValuePairs;

            using var context = GetContext();
            List<WebApplication.Data.Entitis.Inventory> getInvent = context.Inventory.Where(i => i.LocationId == storeId).ToList();
                                                                
            Dictionary<WebApplication.BLogic.Library.Product, int> DictOfProductsAndPrices = new Dictionary<WebApplication.BLogic.Library.Product, int>();
            foreach (WebApplication.Data.Entitis.Inventory item in getInvent)
            {
                DictOfProductsAndPrices.Add(new WebApplication.BLogic.Library.Product()
                {
                    InventoryId = item.InventoryId,
                    Name = context.Products.Single(p => p.ProductId == item.ProductId).Name,
                    Price = context.Products.Single(p => p.ProductId == item.ProductId).Price,
                    Id = item.ProductId
                },
                    (int)item.Quantity);
            }
            return DictOfProductsAndPrices;

        }

        public void AddNewOrder(WebApplication.BLogic.Library.Order _ord)
        {
            data.Orders Ord = Mapper.MapOrders(_ord); //Take in Order Object and mapp to DB
            Ord.OrderId = 0;
            context.Add(Ord); // Add to DB
            context.SaveChanges(); //Save DB
        }

        public void UpdateInventory(WebApplication.BLogic.Library.InventoryItem invent)
        {
            data.Inventory Invent = Mapper.MapInventoryItem(invent); //Takes in InventoryItem object and maps to Db
            context.Update(Invent);
            context.SaveChanges();
        }

        public void UpdateInventory(int storeId, int prodId, int quantity)
        {
            var Invent = context.Location.Find(storeId);
            foreach(var item in Invent.Inventory)
            {
                if(item.ProductId == prodId)
                {
                    item.Quantity -= quantity;
                }
            }
        }

        public void UpdateOrderDetails(WebApplication.BLogic.Library.OrderDetails od)
        {
            data.OrderDetail Od = Mapper.MapOrderDetails(od);
            context.Update(Od);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
