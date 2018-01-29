using System;
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
        public ActionResult Index()
        {
            var model = GetCustomers();
            var modelDto = model
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName
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
                    CustomerId = 1,
                    FirstName = "Mariusz",
                    LastName = "Przybysz"
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Jan",
                    LastName = "Kowalski"
                }
            };
        }
    }
}