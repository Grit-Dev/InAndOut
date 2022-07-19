using InAndOut.Data;
using InAndOut.Models;
using InAndOut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

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
            IEnumerable<Expense> expenseList = _db.Expenses;

            foreach (var obj in expenseList)
            {
                //for every obj in the obj list. set the expense type to be the first entry for that Id
                //then give me the expense type
                obj.ExpenseType = _db.ExpenseTypes.FirstOrDefault(u => u.ID == obj.ExpenseTypeId);
                
            }

            return View(expenseList);
        }

        //Get: Create View Page 
        public IActionResult Create()
        {
            /*            //loosely typed - Not best practised 
                        IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.ID.ToString()
                        });
            */
            //Storing IENUM of selectList Item names TypeDropdown from the DB, creating a new list
            //and passing it to the view bag 


            /* ViewBag.TypeDropDown = TypeDropDown;*/


            //Strongly typed - Much better 
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.ID.ToString()
                })

            };

            return View(expenseVM);

        }

        [HttpPost] //Post request for when use hits save
        [ValidateAntiForgeryToken] //Security token protection
        public IActionResult Create(ExpenseVM pExpenses)
        {
            //Check if something is valid or defined in Expense
            if (ModelState.IsValid)
            {
                //Do not do this in production - setting the ID - Good for testing
                //pExpenses.ExpenseTypeId = 1;


                _db.Expenses.Add(pExpenses.Expense);
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
            var obj = _db.Expenses.Find(id);

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
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET-Update
        public IActionResult Update(int? id)
        {
            ExpenseVM expVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.ID.ToString()
                })
            };


            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            expVM.Expense = _db.Expenses.Find(id);

            if (expVM.Expense == null)
            {
                return NotFound();
            }
            return View(expVM);
        }

        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
