using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Expense_Tracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            //last 7 Days
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransactions = await _context.Transactions
                .Include(x => x.Category)
                .Where(y => y.Date >= StartDate && y.Date <= EndDate)
                .ToListAsync();

            //Total income
            int TotalIncome = SelectedTransactions
                .Where(x => x.Category.Type == "Income")
                .Sum(y => y.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("₹0");

            //Total Expense
            int TotalExpense = SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .Sum(j => j.Amount);
            ViewBag.TotalExpense = TotalExpense.ToString("₹0");

            //Balance
            int Balance = TotalIncome - TotalExpense;
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-IN");
            cultureInfo.NumberFormat.CurrencyNegativePattern = 1;
            ViewBag.Balance = String.Format(cultureInfo, "{0:C0}", Balance);

            // Doughnut chart - Expense by category
            ViewBag.DoughnutChartData = SelectedTransactions
               .Where(i => i.Category.Type == "Expense")
               .GroupBy(j => j.Category.CategoryId)
               .Select(k => new
               {
                   categoryTitleWithIcon = k.First().Category.Icon + " " + k.First().Category.Title,
                   amount = k.Sum(j => j.Amount),
                   formattedAmount = k.Sum(j => j.Amount).ToString("₹0"),
               })
               .ToList();

            return View();
        }
    }
}
