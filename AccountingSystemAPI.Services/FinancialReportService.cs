using AccountingSystemAPI.DataAccess;
using AccountingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemAPI.Services
{
    public class FinancialReportService
    {
        private readonly ApplicationDbContext _db;
        public FinancialReportService(ApplicationDbContext db)
        {
            _db = db;
        }
        public FinancialReport GenerateFinancialReport(int productId, DateTime startDate, DateTime endDate)
        {
            
            var orders = _db.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate && o.ProductId==productId)
                .ToList();

            decimal totalIncome = orders.Sum(o => (o.SellingPrice ?? 0) *(o.SellingUnit));

            
            

            return new FinancialReport
            {
                TotalIncome = totalIncome,
                //TotalExpenses = totalExpenses,
                //ProfitOrLoss = profitOrLoss
            };
        }
    }
}
