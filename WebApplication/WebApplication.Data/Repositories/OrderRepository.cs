using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using NLog;
using Microsoft.EntityFrameworkCore;
using BLogic.Library.Interfaces;
using WebApplication.BLogic.Library;

namespace WebApplication.Data
{
    class OrderRepository : IOrderRepository
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
        public OrderRepository(Project1Context context)
        {
           
            this.context = context;

        }

        public void AddNewOrder(Order _ord)
        {
            Orders Ord = Mapper.MapOrders(_ord);
            context.Add(Ord);
            context.SaveChanges();
        }

        public void AddNewOrder()
        {
            throw new NotImplementedException();
        }

    }
}
