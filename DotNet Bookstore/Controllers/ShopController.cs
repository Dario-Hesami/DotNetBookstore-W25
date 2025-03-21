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

        //  Get: /Shop/ShopByCategory/5
        public IActionResult ShopByCategory(int id)
        {
            // Display the category name on the page based on the ID - store category name in the ViewData object
            var category = _context.Categories.Find(id);

            // return to /shop/index if category not found
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["Category"] = category.Name;

            // query the books filtered by the selected CategoryID parameter
            var books = _context.Books.Where(b => b.CategoryId == id)
                .OrderBy(b => b.Title)
                .ToList();

            // send the books to the view for display   
            return View(books); 
        }
    }
}
