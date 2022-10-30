using Microsoft.AspNetCore.Mvc;
using Mobi__Shop.Models;
using Mobi__Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository IProductRepository;

        public ProductController(IProductRepository _IProductRepository)
        {
            IProductRepository = _IProductRepository;
        }
        public IActionResult Index()
        {
            List<Product> Products = IProductRepository.GetAll();

            return View(Products);
        }
        public IActionResult Add()
        {
            ProductViewModel p = new ProductViewModel();
            return View(p);
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid == true)
            {
                IProductRepository.AddNewProduct(productViewModel);
                return RedirectToAction("Index");

            }
            return BadRequest(ModelState);
        }
        public IActionResult EditProduct(int id)
        {
            ProductViewModel p = IProductRepository.GetProductByID(id);
            if (p.Name != null)
            
                return View(p);


            return BadRequest("Id not correct");
        }
        [HttpPost]
        public IActionResult EditProduct(int id, ProductViewModel productViewModel)
        {
            if (ModelState.IsValid == true)
            {
                IProductRepository.Edit(id, productViewModel);
                return RedirectToAction("Index");
            }
            return BadRequest(ModelState);

        }
        public IActionResult DeleteProduct(int id)
        {
            ProductViewModel productViewModel = IProductRepository.GetProductByID(id);
            if (productViewModel.Name !=null)
            
                return View(productViewModel);

            return BadRequest("ID Not Found");
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id, ProductViewModel productViewModel)
        {

            try
            {
                IProductRepository.DeleteProductById(id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }



        }


        public IActionResult GetProducBySearch(string name)
        {
            ProductViewModel productViewModel = IProductRepository.SearchWithPartOfName(name);
            if (productViewModel != null)
            {
                return View(productViewModel);

            }
            return BadRequest(ModelState);
        }
        public IActionResult GetProducByName(string name)
        {
            ProductViewModel productViewModel = IProductRepository.GetByName(name);
            if (productViewModel != null)
            {
                return View(productViewModel);

            }
            return BadRequest(ModelState);
        }

        public IActionResult GetProductById(int id)
        {
            ProductViewModel productViewModel = IProductRepository.GetProductByID(id);
            if (productViewModel != null)
            {
                return View(productViewModel);

            }
            return BadRequest(ModelState);
        }
        public IActionResult GetProductsByBrand(string BrandName)
        {
            List<ProductViewModel> productViewModel = IProductRepository.GetProductsByBrand(BrandName);
            if (productViewModel != null)
            {
                return View(productViewModel);

            }
            return BadRequest(ModelState);

        }
        public IActionResult GetProductsByProductionYear(int ProductionYear)
        {
            List<ProductViewModel> productViewModel = IProductRepository.GetProductsByProductionYear(ProductionYear);
            if (productViewModel != null)
            {
                return View("GetProductsByBrand", productViewModel);

            }
            return BadRequest(ModelState);

        }
        public IActionResult GetProductsWithStock()
        {
            List<ProductViewModel> productViewModel = IProductRepository.GetProductsWithStock();
            if (productViewModel != null)
            {
                return View("GetProductsByBrand", productViewModel);

            }

            return BadRequest(ModelState);
        }

        public IActionResult GetProductsWithoutStock()
        {
            List<ProductViewModel> productViewModel = IProductRepository.GetProductsOutOfStock();
            if (productViewModel != null)
            {
                return View("GetProductsByBrand", productViewModel);

            }
            return BadRequest(ModelState);

        }
        public IActionResult GetProductsWithCategoryName(string CategoryName)
        {
            List<ProductViewModel> productViewModel = IProductRepository.FilterProductsWithCategoryName(CategoryName);
            if (productViewModel != null)
            {
                return View("GetProductsByBrand", productViewModel);

            }
            return BadRequest(ModelState);
        }

        public IActionResult AddingProductToShopingCart(int id)
        {
            ProductViewModel productViewModel =  IProductRepository.GetProductByID(id);
         return View(productViewModel);
        }
        
        
    }
}
