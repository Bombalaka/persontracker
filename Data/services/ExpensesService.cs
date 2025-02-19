using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using persontracker.Models;

namespace persontracker.Data.services
{
    public class ExpensesService : IExpensesService
    {

        private readonly FinanceAppContextDb _context;

        public ExpensesService(FinanceAppContextDb context)
        {
            _context = context;
        }
        public async Task Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return expenses;
        }
    }
}