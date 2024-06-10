using ExpensesApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ExpensesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // The database that we are going to use for the application
        private readonly ExpensesDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ExpensesDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        // View all expenses
        public IActionResult Expenses()
        {
            return View();
        }

        // In this method we are creating or editing an expense
        public IActionResult CreateEditExpense()
        {
            // Check if we are creating a new expense or editing an existing one

            return View();
        }

        public IActionResult DeleteExpense()
        {
            // Check the expense

            return RedirectToAction("Expenses");
        }

        public IActionResult CreateEditExpenseForm(Expense model)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
