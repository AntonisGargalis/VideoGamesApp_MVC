using Microsoft.AspNetCore.Mvc;
using VideoGames.DataAccess.Data;
using VideoGames.DataAccess.Repository.IRepository;
using VideoGames.Models;

namespace VideoGamesApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
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
                _unitOfWork.Category.Add(obj); // add the object of new category to the database
                _unitOfWork.Save();       // save and update the changes
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");  // redirect to category list
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDv = _unitOfWork.Category.Get(u => u.Id == id);
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
                _unitOfWork.Category.Update(obj); // add the object of new category to the database
                _unitOfWork.Save();       // save and update the changes
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
            Category? categoryFromDv = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDv == null)
            {
                return NotFound();
            }
            return View(categoryFromDv);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();       // save and update the changes
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");  // redirect to category list
        }
    }
}
