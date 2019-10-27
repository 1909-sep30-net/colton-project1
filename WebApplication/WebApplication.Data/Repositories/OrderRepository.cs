using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using NLog;
using Microsoft.EntityFrameworkCore;
using BLogic.Library.Interfaces;
using WebApplication.BLogic.Library;
using data = WebApplication.Data.Entitis;

namespace WebApplication.Data
{
    public class OrderRepository : IOrderRepository
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
        public OrderRepository(data.Project1Context context)
        {
           
            this.context = context;

        }

        public void AddNewOrder(Order _ord)
        {
            data.Orders Ord = Mapper.MapOrders(_ord);
            context.Add(Ord);
            context.SaveChanges();
        }

        public void AddNewOrder()
        {
            throw new NotImplementedException();
        }

    }
}
