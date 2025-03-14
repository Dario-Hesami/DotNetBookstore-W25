using DotNet_Bookstore.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Bookstore.Controllers
{
    public class ShopController : Controller
    {
        // Class level DBContext connenction object
        private readonly ApplicationDbContext _context;

        // Constructor that accepts the DBContext object
        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();
            return View(categories);
        }
    }
}
