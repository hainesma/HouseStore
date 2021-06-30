using HouseStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HouseStore.Controllers
{
    public class StorefrontController : Controller
    {

        HousesContext db = new HousesContext();
        public IActionResult Index()
        {
            List<House> houses = db.Houses.ToList();
            return View(houses);
        }

        public IActionResult Buy(int id)
        {
            House h = db.Houses.Find(id);
            return View(h);
        }

        [HttpPost]
        public IActionResult Buy(House h)
        {
            h.Quantity = 0;
            db.Houses.Update(h);
            return RedirectToAction("Index", "Storefront");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
