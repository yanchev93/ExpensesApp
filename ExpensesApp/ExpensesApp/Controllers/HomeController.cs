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
            var allExpenses = _dbContext.Expenses.ToList();

            return View(allExpenses);
        }

        // In this method we are creating or editing an expense (nullable id if we are creating something)
        public IActionResult CreateEditExpense(int? id)
        {
            // Check if we are creating a new expense or editing an existing one
            if (id != null)
            {
                // Edit an expense -> load an expense by Id
                var expenseInDb = _dbContext.Expenses.SingleOrDefault(expense => expense.Id == id);
                return View(expenseInDb);
            }

            return View();
        }

        public IActionResult DeleteExpense(int id)
        {
            // Delete expense and redirect them to all expenses after deleting and saving the changes
            // SingleOrDefault will throw an error if there is more than 1 of the exact ids (EFC-SQL secure we don't have repeatable ids)
            var expenseToDelete = _dbContext.Expenses.SingleOrDefault(expense => expense.Id == id);
            _dbContext.Expenses.Remove(expenseToDelete);
            _dbContext.SaveChanges();

            return RedirectToAction("Expenses");
        }

        public IActionResult CreateEditExpenseForm(Expense model)
        {
            if (model.Id == 0)
            {
                // Creating expense
                _dbContext.Add(model);
            }
            else
            {
                // Editing(updating) an existing expense
                _dbContext.Update(model);
            }

            _dbContext.SaveChanges();

            return RedirectToAction("Expenses");
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
