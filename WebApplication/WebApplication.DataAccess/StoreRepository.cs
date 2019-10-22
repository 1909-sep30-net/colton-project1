using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using NLog;
using Microsoft.EntityFrameworkCore;
using WebApplication.BLogic.Library;



namespace WebApplication.DataAccess
{
    public class StoreRepository : IStoreRepository, IDisposable
    {
        /// <summary>
        /// A repository for data access for store objects and their Locations/Addresses.
        /// </summary>
        //private readonly ICollection<Address> _data;
        private readonly Project1Context _dbContext;
        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();



        public StoreRepository(Project1Context dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        //public List<BusinessLogic.Library.Location> GetLocationByAddress(string input = null)
        //{
        //    List<DataAccess.Entities.Location> items = _dbContext.Location
        //        .Include(r => r.Orders).AsNoTracking();

        //    if (input != null)
        //    {
        //        items = items.Where(r => r.Address.Contains(input));
        //    }
        //    return items.Select(Mapper.MapLocation);
        //}
        public BLogic.Library.Location GetLocationById(int id) =>
            Mapper.MapLocation(_dbContext.Location.Find(id));



        public void AddCustomer(WebApplication.BLogic.Library.Customer customer)
        {
            _dbContext.Customer.Add(Mapper.MapCustomer(customer));
        }

        //public int GetCustomersIdByName(string FirstName, string LastName)
        //{
        //    return _dbContext.Customer
        //        .Include(o=>o.Id)
        //        .Where(r => r.FirstName.Contains(FirstName))
        //        .Select(Mapper.MapCustomer);
        //}
        public List<WebApplication.BLogic.Library.Order> GetOrderHistory(int search)
        {
            return _dbContext.Orders
                 .Include(o => o.Customer)
                 .Include(o => o.Location)
                 .Include(o => o.OrderDetails)
                 .ThenInclude(od => od.Product)
                 .Where(r => r.Location.Id.Equals(search))
                 .Select(Mapper.MapOrders).ToList();
        }

        public List<BLogic.Library.Customer> GetCustomerByName(string search = null)
        {

            return _dbContext.Customer

                .Where(r => r.FirstName.Contains(search))
                .Select(Mapper.MapCustomer).ToList();
        }
        public List<BLogic.Library.Location> GetAllLocations()
        {
            return _dbContext.Location
                .Select(Mapper.MapLocation).ToList();

        }
        public List<BLogic.Library.Customer> GetAllCustomers()
        {
            return _dbContext.Customer
                    .Select(Mapper.MapCustomer).ToList();
        }
        public void AddOrder(Order order)
        {

            _dbContext.Orders.Add(Mapper.MapOrders(order));
            // _dbContext.SaveChanges();
            //if (location.Id != 0)
            //{
            //    s_logger.Warn($"Order to be  added has an ID ({location.Id}) already: ignoring.");
            //}

            //s_logger.Info($"Adding order to store with ID {location.Id}");


        }
        public List<BLogic.Library.Product> GetProducts()
        {
            return _dbContext.Product
                .Select(Mapper.MapProduct).ToList();

        }
        public List<BLogic.Library.Customer> GetCustomer(string FirstName, string LastName)
        {
            return _dbContext.Customer
                .Where(o => o.FirstName == FirstName && o.LastName == LastName)
                .Select(Mapper.MapCustomer).ToList();
        }
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
        public void UpdateInventory(InventoryItem inventoryItem)
        {

            _dbContext.Inventory.Update(Mapper.MapInventoryItem(inventoryItem));
        }

        public static Project1Context GetContext()
        {
            string connectionString = "Server=tcp:coltonclary0806.database.windows.net,1433;Initial Catalog=Project0;Persist Security Info=False;User ID=coltonclary0806;Password=Maplestaple1?;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30:";

            DbContextOptions<Project1Context> options = new DbContextOptionsBuilder<Project1Context>()
                .UseSqlServer(connectionString)
                .Options;

            return new Project1Context(options);
        }

        public void Save()
        {
            s_logger.Info("Saving changes to the database");
            _dbContext.SaveChanges();
        }
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                _disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }

    }
}
