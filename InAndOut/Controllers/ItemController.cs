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

        //Get-Create: Get the Create View Page
        public IActionResult Create()
        {
            return View();
        }

        //Post-Create: Needed to send info filled in to be saved
        [HttpPost]
        [ValidateAntiForgeryToken] //Check if the user has a token and still logged in - I can add middleware later to apply this everywhere
        public IActionResult Create(Item pItem)
        {
            _db.Items.Add(pItem); //Adds Obj to the Db 
            _db.SaveChanges(); //Saves and updates the DB

            return RedirectToAction("Item", "Index");

        }

        public IActionResult Details(Item pItem)
        {
          
            //If check works - Find the ID and if the item check is null or cannot be found - Redirect 
            var itemCheck = _db.Items.Find(pItem.ID);

            if (itemCheck == null)
            {
                //Inform user the Id cannot be found within the Database = Use 
                RedirectToAction("Index");
            }

            //Else Return the view

            return View(itemCheck);

        }
    }
}


