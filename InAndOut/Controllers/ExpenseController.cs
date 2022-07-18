using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {

        // Read only of the dbContext
        private readonly AppDbContext _db;

        public ExpenseController(AppDbContext db)
        {
            //Pass the db to _db so it is encapsulated
            _db = db;
        }   

        public IActionResult Index()
        {
            //Pass the db Expenses Model Class, and return it to view
            var expenseList = _db.Expenses;

            return View(expenseList);
        }

        //Get: Create View Page 
        public IActionResult Create()
        {

           return View();   
            
        }

        [HttpPost] //Post request for when use hits save
        [ValidateAntiForgeryToken] //Security token protection
        public IActionResult Create(Expense pExpenses)
        {
            //Check if something is valid or defined in Expense
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(pExpenses);
                _db.SaveChanges();

                //Once complete redirect the user to the Index(controller/Action)
                return RedirectToAction("Index");
            }

            return View(pExpenses);
            
        }
    }
}
