using Microsoft.AspNetCore.Mvc;
using VideoGames.DataAccess.Data;
using VideoGames.DataAccess.Repository.IRepository;
using VideoGames.Models;

namespace VideoGamesApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db) 
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category>  objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj); // add the object of new category to the database
                _categoryRepo.Save();       // save and update the changes
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");  // redirect to category list
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id==0)
            {
               return NotFound();
            }
            Category? categoryFromDv = _categoryRepo.Get(u => u.Id == id);
            //Category? categoryFromDv1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDv2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDv == null)
            {
                return NotFound();
            }
            return View(categoryFromDv);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(obj); // add the object of new category to the database
                _categoryRepo.Save();       // save and update the changes
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");  // redirect to category list
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDv = _categoryRepo.Get(u => u.Id == id);
            if (categoryFromDv == null)
            {
                return NotFound();
            }
            return View(categoryFromDv);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _categoryRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();       // save and update the changes
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");  // redirect to category list
        }
    }
}
