using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using persontracker.Models;

namespace persontracker.Data.services
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll();
        Task Add(Expense expense);

        IQueryable<Expense> GetChartData();
        
    }
}