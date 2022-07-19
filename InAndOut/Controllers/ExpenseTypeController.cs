using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {

        // Read only of the dbContext
        private readonly AppDbContext _db;

        public ExpenseTypeController(AppDbContext db)
        {
            //Pass the db to _db so it is encapsulated
            _db = db;
        }

        public IActionResult Index()
        {
            //Pass the db Expenses Model Class, and return it to view
            IEnumerable<ExpenseType> expenseList = _db.ExpenseTypes;

            return View(expenseList);
        }

        //Get: Create View Page 
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost] //Post request for when use hits save
        [ValidateAntiForgeryToken] //Security token protection
        public IActionResult Create(ExpenseType pExpenses)
        {
            //Check if something is valid or defined in Expense
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(pExpenses);
                _db.SaveChanges();

                //Once complete redirect the user to the Index(controller/Action)
                return RedirectToAction("Index");
            }

            return View(pExpenses);

        }


        //Get Delete Id of obj
        // GET-Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ExpenseTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET-Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
