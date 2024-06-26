﻿using Microsoft.AspNetCore.Mvc;
using VideoGames.DataAccess.Repository.IRepository;
using VideoGames.Models;

namespace VideoGamesApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj); 
                _unitOfWork.Save();       
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");  
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productyFromDv = _unitOfWork.Product.Get(u => u.Id == id);
            if (productyFromDv == null)
            {
                return NotFound();
            }
            return View(productyFromDv);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj); 
                _unitOfWork.Save();       
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");  
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productyFromDv = _unitOfWork.Product.Get(u => u.Id == id);
            if (productyFromDv == null)
            {
                return NotFound();
            }
            return View(productyFromDv);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();       // save and update the changes
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");  // redirect to category list
        }
    }
}
