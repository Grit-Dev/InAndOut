using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        //Dependency Injection: 
        private readonly AppDbContext _db;

        public ItemController(AppDbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items; 

            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
