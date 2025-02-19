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
        List<object> GetChartData();
        Task<Expense> GetById(int id);
        Task Update(Expense expense);
        Task Delete(int id);
        
    }
}