using Microsoft.AspNetCore.Mvc;
using Mobi__Shop.Models;
using Mobi__Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository CartRepository;

        public CartController(ICartRepository _CartRepository)
        {
           CartRepository = _CartRepository;
        }
        public IActionResult Index(ProductViewModel productViewModel)
        {

            CartViewModel cartViewModel = new();
            cartViewModel.ID = 0;
            cartViewModel.ProductName = productViewModel.Name;
            cartViewModel.ProductPrice = productViewModel.Price;
            cartViewModel.Username = productViewModel.UserName;
            ViewBag.Helper = cartViewModel;
            Cart cart = new();

            //cart.UserName = productViewModel.UserName;
            cart.ProductName = cartViewModel.ProductName;
            cart.ProductPrice = cartViewModel.ProductPrice;
            cart.UserName = cartViewModel.Username;
            if (cartViewModel.Username !=null)
            {
                CartRepository.Add(cart);


            }
            string SessionName = HttpContext.User.Identity.Name;

            List<Cart> allCarts =  CartRepository.GetAll(SessionName);
            if (allCarts.Count >0)
            {
                List<CartViewModel> cartViewModels = new();
                foreach (var c in allCarts)
                {
                    CartViewModel cartViewModel1 = new();
                    cartViewModel1.ID = c.ID;
                    cartViewModel1.ProductName = c.ProductName;
                    cartViewModel1.ProductPrice = c.ProductPrice;
                    cartViewModel.Username = c.UserName;
                    cartViewModels.Add(cartViewModel1);
                }
                ViewBag.Num = allCarts.Count;
                TempData["CartsCount"] = ViewBag.Num;
                return View(cartViewModels);


            }
            ViewBag.Num = allCarts.Count;
            TempData["CartsCount"] = ViewBag.Num;


            return View(new List<CartViewModel>());
            


        }
        
        public IActionResult Buy(CartViewModel cartViewModel)
        {
            if (ModelState.IsValid==true)
            {
                CartRepository.Remove(cartViewModel.ID,cartViewModel.ProductName);
                return RedirectToAction("Index");
            }
            return BadRequest();
            
        }
    }
}
