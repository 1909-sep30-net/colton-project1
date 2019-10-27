using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLogic.Library.Interfaces;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICustomerRepo _repository;

        public OrderController(ICustomerRepo repository)
        {
            _repository = repository;
        }
        public ActionResult CustomerOrders(int id)
        {
            List<BLogic.Library.Order> orders = _repository.GetOrdersByCustId(id); //List of BL Orders that comes from DB given id

            List<OrderViewModel> orderViewModels = orders.Select(o => new OrderViewModel //List of OrderViewModels to fill in on View
            {
                CustomerId = o.CustomerId/* ?? throw new ArgumentException("Argument cannot be null", nameof(orders))*/,
                OrderId = o.Id,
                OrderDate = o.OrderDateTime /*?? throw new ArgumentException("Argument cannot be null", nameof(orders))*/,
                Total = o.Total,
                StoreId = o.LocationId /*?? throw new ArgumentException("Argument cannot be null", nameof(orders))*/,
            }).ToList();

            return View("CustomerOrders", orderViewModels); //returns View with string and List of Models
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
    }
}