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
            List<House> houses = db.Houses.Where(x => x.Quantity == 1).ToList();
            return View(houses);
        }

        // This first Buy method return the Buy view for an individual property
        public IActionResult Buy(int id)
        {
            House h = db.Houses.Find(id);
            return View(h);
        }

        // The second Buy method posts an updated house object to the DB,
        // with quantity set to 0.
        [HttpPost]
        public IActionResult Buy(House h)
        {
            h.Quantity = 0;
            db.Houses.Update(h);
            db.SaveChanges();
            return RedirectToAction("Index", "Storefront");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
