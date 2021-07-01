using HouseStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseStore.Controllers
{
    public class ProductController : Controller
    {
        HousesContext db = new HousesContext();
        
        public IActionResult Index()
        {
            List<House> houses = db.Houses.ToList();
            return View(houses);
        }
    }
}
