﻿using InAndOut.Data;
using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly AppDbContext _db; 

        //Dependency injection
        public ExpenseTypeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var typeObj = _db.ExpenseTypes;

            return View(typeObj);
        }
    }
}
