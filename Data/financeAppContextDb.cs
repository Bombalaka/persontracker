using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using persontracker.Models;


namespace persontracker.Data
{
    public class FinanceAppContextDb : DbContext
    {
        public FinanceAppContextDb(DbContextOptions<FinanceAppContextDb> options) : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
    }
}