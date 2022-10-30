using Microsoft.AspNetCore.Mvc;
using Mobi__Shop.Models;
using Mobi__Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository CategoryRepository;

        public CategoryController(ICategoryRepository _CategoryRepository)
        {
            CategoryRepository = _CategoryRepository;
        }
        public IActionResult Index()
        {
            List<CategoryViewModel> Names = CategoryRepository.GetAllCategoryNames();
            return View(Names);
        }
        public IActionResult GetProductsWithCategoryName(string Name)
        {
            List<ProductViewModel> productViewModels = CategoryRepository.GetProductsWithCategoryName(Name);
            return View(productViewModels);
        }
        public IActionResult GetProductsWithCategoryID(int id)
        {
            List<ProductViewModel> productViewModels = CategoryRepository.GetProductsWithCategoryID(id);
            return View("GetProductsWithCategoryName", productViewModels);
        }
        public IActionResult Add()
        {
            CategoryViewModel categoryViewModel = new();
            return View(categoryViewModel);
        }
        [HttpPost]
        public IActionResult Add(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid== true)
            {
                CategoryRepository.AddNewCategory(categoryViewModel);
                return RedirectToAction("Index", "Category");

            }
            return BadRequest(ModelState);
        }
        public IActionResult Update(int id)
        {
            CategoryViewModel oldCat = CategoryRepository.GetCategoryById(id);
            if (oldCat.Name != null)
                return View(oldCat);
            return BadRequest("Category Id not Exist");

            
        }
        [HttpPost]
        public IActionResult Update(int id, CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid== true)
            {
                CategoryRepository.UpdateCategoryByID(id, categoryViewModel);
                return RedirectToAction("Index", "Category");
            }
            return BadRequest(ModelState);
        }
        public IActionResult DeleteById(int id)
        {
            try
            {
              CategoryViewModel oldcat =   CategoryRepository.GetCategoryById(id);
                if (oldcat.Name !=null)
                  return View(oldcat);
                return BadRequest("ID not found");

                
            }
            catch (Exception)
            {
                return BadRequest("Category Have Childs");

                
            }
        }
        [HttpPost]
        public IActionResult DeleteById(int id , CategoryViewModel categoryViewModel)
        {
            try
            {
                CategoryRepository.DeleteCategoryByID(id);
               return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception)
            {
                return BadRequest("Category Have Childs");

            }

        }
        public IActionResult DeleteByName(string Name)
        {
            try
            {
                CategoryRepository.DeleteCategoryByName(Name);
                return RedirectToAction("Index", "Category");
            }
            catch (Exception)
            {
                return BadRequest("Category Have Childs");


            }
        }


    }
}
