using DeveloperBook.DataAccess;
using DeveloperBook.DataAccess.Repository.IRepository;
using DeveloperBook.Models;
using Microsoft.AspNetCore.Mvc;
//using DeveloperBook.Utility;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeveloperBookWeb.Areas.Admin.Controllers
{
	//[Area("Admin")]
	//[Authorize(Roles = SD.Role_Admin)]
	public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objCoverTypeList = (IEnumerable<Product>)_unitOfWork.Product.GetAll();
            return View(objCoverTypeList);
        }

       
        //GET
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Product product = new();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text= u.Name,
                    Value = u.Id.ToString()
                });

            IEnumerable<SelectListItem> CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            if (id == null || id == 0)
            {
                //create product
                ViewBag.CategoryList = CategoryList;
                return View(product);
            }
            else
            {
                //update product
            }

            return View(product);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "CoverType updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var ProductFromDbFirst = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == id);

            if (ProductFromDbFirst == null)
            {
                return NotFound();
            }

            return View(ProductFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("DeletePOST")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
