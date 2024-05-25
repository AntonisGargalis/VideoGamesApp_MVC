﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VideoGames.DataAccess.Repository.IRepository;
using VideoGames.Models.ViewModels;
using VideoGames.Models;
using Microsoft.AspNetCore.Authorization;
using VideoGames.Utility;

namespace VideoGamesApp.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> objProductList = _unitOfWork.Company.GetAll().ToList();

            return View(objProductList);
        }
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Company companyObj)
        {
            if (ModelState.IsValid)
            {
                               
                if (companyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(companyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(companyObj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(companyObj);
            }

        }

        #region Api Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyTobeDeleted = _unitOfWork.Company.Get(u => u.Id == id);

            if (companyTobeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            
            _unitOfWork.Company.Remove(companyTobeDeleted);
            _unitOfWork.Save();

            return Json(new { success = false, message = "Delete Successful" });

        }

        #endregion
    }
}
