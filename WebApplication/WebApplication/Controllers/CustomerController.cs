﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLogic.Library.Interfaces;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo _repository;
        public CustomerController(ICustomerRepo repository)
        {
            _repository = repository;
        }
        // GET: Customer
        public ActionResult Index()
        {
            List<BLogic.Library.Customer> customers = _repository.GetAllCustomers();

            var viewModel = customers.Select(c => new CustomerViewModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
            });
            return View(viewModel);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel viewModel)
        {
            try
            {
                var newCust = new BLogic.Library.Customer
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName
                };

                _repository.AddNewCustomer(newCust);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(CustomerViewModel customer)
        {

            try
            {

                List<BLogic.Library.Customer> cust = _repository.GetCustomerByFirstName(customer.FirstName);

                var viewModel = cust.Select(c => new CustomerViewModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName
                });

                // _repository.GetCustomerByFirstName(viewModel);

                return View("Results", viewModel);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            };

        }

        public ActionResult PlaceOrder(int id)
        {
            List<BLogic.Library.Location> stores = _repository.GetAllStores();

            OrderViewModel orderViewModel = new OrderViewModel
            {
                CustomerId = id,

                AllStores = stores.Select(s => new LocationViewModel

                {
                    Id = s.Id,
                    City = s.Address
                }).ToList()

            };
            return View(orderViewModel);
        }

        /// <summary>
        /// See Inventory is what customer submits after selecting store number by dropdown
        /// </summary>
        /// <param name="orderviewmodel">OrderViewModel is passed in</param>
        /// <returns> view</returns>
        public ActionResult SeeInventory(OrderViewModel orderViewModel)
        {
            Dictionary<BLogic.Library.Product, int> dic2 = _repository.GetInventoryByStoreId(orderViewModel.StoreId); //Dictionary of Products and ints, filled in from Repository and passed StoreId of OrderViewModel

            SeeInventoryViewModel seeInventory = new SeeInventoryViewModel
            {
                CustomerId = orderViewModel.CustomerId,
                StoreId = orderViewModel.StoreId,

                Inventory = dic2.Select(d => new ProductViewModel
                {
                    Name = d.Key.Name,
                    Price = d.Key.Price,
                    ProductId = d.Key.Id,
                    ProductQuant = 0,
                    MaxQuant = d.Value,
                    InventoryId = d.Key.InventoryId,

                }).ToList()
            };
            return View(seeInventory);
        }

        //public ActionResult PlaceOrder3(Order2ViewModel order2)
        //{



        //    Order order = new Order
        //    {
        //        CustomerId = order2.CustomerId,
        //        StoreId = order2.StoreId,
        //        DateOfOrder = DateTime.Now,
        //        cart = new Dictionary<Product, int>()

        //    };
        //    foreach (var item in order2.Inventory)
        //    {
        //        if (item.ProductQuant != 0)
        //        {
        //            Product product = new Product
        //            {
        //                ProductId = item.ProductId,
        //                Name = item.Name,
        //                Price = item.Price
        //            };

        //            OrderDetails taco = new OrderDetails
        //            {
        //                OrderDeatailId = 0,
        //                ProductId = item.ProductId,
        //                ProductQuant = item.ProductQuant,
        //            };

        //            order.ProductOrdered.Add(taco);

        //            BusinessLogic.Inventory inv = new BusinessLogic.Inventory
        //            {
        //                InventoryId = item.InventoryId,
        //                StoreId = order2.StoreId,
        //                ProductId = item.ProductId,
        //                Quantity = item.MaxQuant - item.ProductQuant
        //            };

        //            _repository.UpdateInventory(inv);

        //            order.cart[product] = item.ProductQuant;
        //        }

        //    }
        //    _repository.AddNewOrder(order);



        //    return RedirectToAction(nameof(Index));
        //}

    }
}