using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lib = WebApplication.BLogic.Library;
using Ent = WebApplication.Data;

namespace WebApplication.Data
{
    class Mapper
    {
        //public static BLogic.Library.Location MapStore(Data.Location stores)

        //{

        //    return new BLogic.Library.Location

        //    {

        //        Id = stores.Id,

        //        Address = stores.Address

        //    };
        //}

        //internal static lib.Location MapStore(object p)
        //{
        //    throw new NotImplementedException();
        //}

        //public static Ent.Location MapDbStores(lib.Location store)

        //{

        //    return new Data.Location

        //    {

        //        Id = store.Id,
                
        //        Address = store.Address
        //    };

        //}
        //public static lib.Product MapProduct(Data.Product products)
        //{
        //    return new lib.Product

        //    {

        //        Name = products.Name,

        //        Price = products.Price,

        //        Id = products.Id


        //    };
        //}
        //public static Data.Product MapDbProduct(lib.Product product)
        //{

        //    return new Data.Product

        //    {

        //        Name = product.Name,

        //        Price = product.Price,

        //        Id = product.Id


        //    };

        //}


        public static lib.Customer MapCustomer(Ent.Customer customer)
        {
            return new lib.Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }

        public static Ent.Customer MapCustomer(lib.Customer customer)
        {
            return new Ent.Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName

            };
        }
        public static lib.Location MapLocation(Ent.Location location)
        {
            return new lib.Location
            {
                Id = location.Id,
                Address = location.Address,
                Inventory = location.Inventory.Select(Mapper.MapInventoryItem).ToList(),
                OrderHistory = location.Orders.Select(Mapper.MapOrders).ToList()


            };
        }

        public static Ent.Location MapLocation(lib.Location location)
        {
            return new Ent.Location
            {
                Id = location.Id,
                Address = location.Address,
                Inventory = location.Inventory.Select(Mapper.MapInventoryItem).ToList(),
                Orders = location.OrderHistory.Select(Mapper.MapOrders).ToList(),


            };
        }
        public static Ent.Orders MapOrders(lib.Order order)
        {
            return new Ent.Orders
            {
                Id = order.Id,
                LocationId = order.Location.Id,
                CustomerId = order.CustomerId,
                OrderDetails = order.OrderDetails.Select(Mapper.MapOrderDetails).ToList(),
                OrderTime = order.OrderDateTime



            };

        }
        public static lib.Order MapOrders(Ent.Orders order)
        {
            return new lib.Order
            {
                Id = order.Id,
                CustomerId = order.CustomerId ?? throw new ArgumentException("Argument cannot be null", nameof(order)),
                LocationId = order.LocationId ?? throw new ArgumentException("Argument cannot be null", nameof(order)),
                OrderDetails = order.OrderDetails.Select(MapOrderDetails).ToList(),
                OrderDateTime = order.OrderTime ?? throw new ArgumentException("Argument cannot be null", nameof(order))
            };
        }
        public static lib.InventoryItem MapInventoryItem(Ent.Inventory inventoryItem)
        {
            return new lib.InventoryItem
            {
                Product = Mapper.MapProduct(inventoryItem.Product),
                Quantity = inventoryItem.Quantity,
                Location = Mapper.MapLocation(inventoryItem.Location)
            };
        }
        public static Ent.Inventory MapInventoryItem(lib.InventoryItem inventoryItem)
        {
            return new Ent.Inventory
            {
                ProductId = inventoryItem.Product.Id,
                LocationId = inventoryItem.Location.Id,

                Quantity = inventoryItem.Quantity,




            };
        }
        public static lib.OrderDetails MapOrderDetails(Ent.OrderDetails orderDetails)
        {
            return new lib.OrderDetails
            {
                Id = orderDetails.Order.Id,
                Quantity = (int)orderDetails.Quantity,
                Product = Mapper.MapProduct(orderDetails.Product)
            };
        }
        public static Ent.OrderDetails MapOrderDetails(lib.OrderDetails orderDetails)
        {
            return new Ent.OrderDetails
            {
                OrderId = orderDetails.Id,
                ProductId = orderDetails.Product.Id,
                Quantity = orderDetails.Quantity


            };
        }
        public static lib.Product MapProduct(Ent.Product product)
        {
            return new lib.Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = (double)product.Price
            };
        }
        public static Ent.Product MapProduct(lib.Product product)
        {
            return new Ent.Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price

            };
        }




    }
}
