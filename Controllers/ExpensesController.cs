using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using persontracker.Data;
using persontracker.Data.services;
using persontracker.Models;

namespace persontracker.Controllers
{

    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;
        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _expensesService.GetAll();
            return View(expenses);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                await _expensesService.Add(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        public IActionResult Getchart()
        {
            var data = _expensesService.GetChartData();
            return Json(data);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var expense = await _expensesService.GetById(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                await _expensesService.Update(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var expense = await _expensesService.GetById(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense); // This will show a confirmation page
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var expense = await _expensesService.GetById(id);
            if (expense == null)
            {
                return NotFound(); // Handle case where the expense no longer exists
            }

            await _expensesService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}