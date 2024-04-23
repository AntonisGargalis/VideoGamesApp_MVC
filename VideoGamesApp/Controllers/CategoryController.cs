using Microsoft.AspNetCore.Mvc;
using VideoGamesApp.Data;
using VideoGamesApp.Models;

namespace VideoGamesApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) 
        { 
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category>  objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _db.Categories.Add(obj); // add the object of new category to the database
            _db.SaveChanges();       // save and update the changes
            return RedirectToAction("Index");  // redirect to category list
        }
    }
}
