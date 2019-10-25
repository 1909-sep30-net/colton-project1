using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lib = WebApplication.BLogic.Library;
using Ent = WebApplication.Data.Entitis;

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


        public static lib.Customer MapCustomer(Ent.Customers customer)
        {
            return new lib.Customer
            {
                Id = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }

        public static Ent.Customers MapCustomer(lib.Customer customer)
        {
            return new Ent.Customers
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName

            };
        }
        public static lib.Location MapLocation(Ent.Location location)
        {
            return new lib.Location
            {
                Id = location.LocationId,
                Address = location.Address,
                Inventory = location.Inventory.Select(Mapper.MapInventoryItem).ToList(),
                OrderHistory = location.Orders.Select(Mapper.MapOrders).ToList()


            };
        }

        public static Ent.Location MapLocation(lib.Location location)
        {
            return new Ent.Location
            {
                LocationId = location.Id,
                Address = location.Address,
                Inventory = location.Inventory.Select(Mapper.MapInventoryItem).ToList(),
                Orders = location.OrderHistory.Select(Mapper.MapOrders).ToList(),


            };
        }
        public static Ent.Orders MapOrders(lib.Order order)
        {
            return new Ent.Orders
            {
                OrderId = order.Id,
                LocationId = order.Location.Id,
                CustomerId = order.Id,
                OrderDetail = order.ProductSelected.Select(MapOrderDetails).ToList(),
                OrderDateTime = order.OrderDateTime



            };

        }
        public static lib.Order MapOrders(Ent.Orders order)
        {
            return new lib.Order
            {
                Id = order.OrderId,
                CustomerId = order.CustomerId,
                LocationId = order.LocationId,
                OrderDateTime = order.OrderDateTime,
                Total = order.Total,
                ProductSelected = order.OrderDetail.Select(MapOrderDetails).ToList()
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
        public static lib.OrderDetails MapOrderDetails(Ent.OrderDetail orderDetails)
        {
            return new lib.OrderDetails
            {
                OrderDetailId = orderDetails.Order.Id,
                ProductQuantity = (int)orderDetails.Quantity,
                ProductId = Mapper.MapProduct(orderDetails.Product)
            };
        }
        public static Ent.OrderDetail MapOrderDetails(lib.OrderDetails orderDetails)
        {
            return new Ent.OrderDetail
            {
                OrderId = orderDetails.OrderDetailId,
                ProductId = orderDetails.ProductId,
                ProductQuantity = orderDetails.ProductQuantity,
                OrderDetailId = orderDetails.OrderDetailId


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