﻿using Microsoft.EntityFrameworkCore;
using FinancialApp.API.Models;

namespace FinancialApp.API.Data
{
    public class FinancialContext : DbContext
    {
        public FinancialContext(DbContextOptions<FinancialContext> opt) : base(opt)
        {
        }
        public DbSet<Income> Incomes { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        internal object TotalIncome(int year, int month)
        {
            throw new NotImplementedException();
        }
    }
}
