using System.Diagnostics;
using LawFirm_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; // Added for List<Case>
using System; // Added for DateTime

namespace LawFirm_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Your database context or services would go here
        // private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger /*, ApplicationDbContext context */)
        {
            _logger = logger;
            // _context = context;
        }

        public IActionResult Index()
        {
            // 1. Fetch data from your database
            var viewModel = new DashboardView
            {
                // Example data fetching (you will replace this)
                TotalCases = 150, // _context.Cases.Count(),
                ActiveClients = 85, // _context.Clients.Count(c => c.IsActive),
                UpcomingHearingsCount = 12, // _context.Hearings.Count(h => h.Date > DateTime.Now),
                TotalLawyers = 24, // _context.Lawyers.Count(),
                
            };

            // 2. Pass the view model to the view
            return View(viewModel);
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