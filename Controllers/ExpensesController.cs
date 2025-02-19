using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using persontracker.Data;

namespace persontracker.Controllers
{
    
    public class ExpensesController : Controller
    {
        private  readonly FinanceAppContextDb _context;

        public ExpensesController(FinanceAppContextDb context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var expenses = _context.Expenses.ToList();
            return View(expenses);
        }
        public IActionResult Create()
        {
            
            return View();
        }

        
    }
}