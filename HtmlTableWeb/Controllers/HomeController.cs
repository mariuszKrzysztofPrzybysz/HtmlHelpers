using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlTableWeb.Dto;
using HtmlTableWeb.Models;

namespace HtmlTableWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string orderBy = null)
        {
            var customers = GetCustomers();

            IOrderedEnumerable<Customer> model;
            switch (orderBy)
            {
                case "CustomerId":
                    model = customers.OrderBy(m => m.CustomerId);
                    break;

                case "FirstName":
                    model = customers.OrderBy(m => m.FirstName);
                    break;

                case "LastName":
                    model = customers.OrderBy(m => m.LastName);
                    break;
                default:
                    model = customers.OrderBy(m => m);
                    break;
            }

            var modelDto = model.Select(m => new CustomerDto
                {
                    CustomerId = m.CustomerId,
                    FirstName = m.FirstName,
                    LastName = m.LastName
                })
                .ToList();

            return View(modelDto);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Mariusz",
                    LastName = "Przybysz"
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Jan",
                    LastName = "Kowalski"
                },
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Marcin",
                    LastName = "Przybysz"
                }
            };
        }
    }
}