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

        public List<object> GetChartData()
        {
            var data = _context.Expenses
                                .GroupBy(e => e.Catagory)
                                .Select(e => new Expense
                                {
                                    Catagory = e.Key,
                                    Amount = e.Sum(e => e.Amount)
                                })
                                .ToList<object>();

            return data;
        }
        public async Task<Expense> GetById(int id)
        {
            return await _context.Expenses.FindAsync(id) ?? throw new InvalidOperationException("Expense not found");
        }
        public async Task Update(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var expense = await GetById(id);
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }
    }
}