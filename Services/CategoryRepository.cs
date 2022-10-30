using Microsoft.EntityFrameworkCore;
using Mobi__Shop.Models;
using Mobi_Shop.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext Context;

        public CategoryRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public List<CategoryViewModel> GetAllCategoryNames()
        {
            List<string> Names = Context.Categories.Select(C => C.Name).ToList();
            List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();

            if (Names != null)
            {
                foreach (var Name in Names)
                {
                    CategoryViewModel categoryViewModel = new()
                    {
                        Name = Name
                    };
                    categoryViewModels.Add(categoryViewModel);
                }
            }
            
            return categoryViewModels;
        }
        public CategoryViewModel GetCategoryById(int id)
        {
            Category category = Context.Categories.FirstOrDefault(C => C.ID == id);
            if (category !=null)
            {
                return new CategoryViewModel()
                {
                    Name = category.Name
                };
            }
            return new CategoryViewModel();

        }
        public List<ProductViewModel> GetProductsWithCategoryName(string CategoryName)
        {
            List<Product> p = Context.Products.Include(P => P.Category).Where(P => P.Category.Name == CategoryName).ToList();
            if (p != null)
            {
                List<ProductViewModel> productViewModel = new List<ProductViewModel>();

                foreach (var Propduct in p)
                {
                    ProductViewModel Pro = new ProductViewModel();

                    Pro.BrandName = Propduct.BrandName;
                    Pro.CategotyID = Propduct.CategoryID;
                    Pro.ImgPath = Propduct.Image;
                    Pro.Name = Propduct.Name;
                    Pro.Price = Propduct.Price;
                    Pro.ProductionYear = Propduct.ProductionYear;
                    Pro.Stock = Propduct.Stock;
                    productViewModel.Add(Pro);
                }
                return productViewModel;
            }
            return new List<ProductViewModel>();
        }
        public List<ProductViewModel> GetProductsWithCategoryID(int id)
        {
            List<Product> p = Context.Products.Include(P => P.Category).Where(P => P.Category.ID == id).ToList();
            if (p != null)
            {
                List<ProductViewModel> productViewModel = new List<ProductViewModel>();

                foreach (var Propduct in p)
                {
                    ProductViewModel Pro = new ProductViewModel();

                    Pro.BrandName = Propduct.BrandName;
                    Pro.CategotyID = Propduct.CategoryID;
                    Pro.ImgPath = Propduct.Image;
                    Pro.Name = Propduct.Name;
                    Pro.Price = Propduct.Price;
                    Pro.ProductionYear = Propduct.ProductionYear;
                    Pro.Stock = Propduct.Stock;
                    productViewModel.Add(Pro);
                }
                return productViewModel;
            }
            return new List<ProductViewModel>();
        }
        public int AddNewCategory(CategoryViewModel categoryViewModel)
        {
            Category category = new()
            {
                Name = categoryViewModel.Name,

            };
            Context.Categories.Add(category);
            int R = Context.SaveChanges();
            return R;

        }
        public int UpdateCategoryByID(int id, CategoryViewModel categoryViewModel)
        {
            Category oldCategory = Context.Categories.FirstOrDefault(C => C.ID == id);
            oldCategory.Name = categoryViewModel.Name;
            int R = Context.SaveChanges();
            return R;

        }
        public int UpdateCategoryByName(string Name, CategoryViewModel categoryViewModel)
        {
            Category oldCategory = Context.Categories.FirstOrDefault(C => C.Name == Name);
            oldCategory.Name = categoryViewModel.Name;
            int R = Context.SaveChanges();
            return R;

        }
        public int DeleteCategoryByID(int id)
        {
            Category oldCategory = Context.Categories.FirstOrDefault(C => C.ID == id);


            if (oldCategory != null)
            {
                
                    Context.Categories.Remove(oldCategory);
                    return Context.SaveChanges();


            }
            return Context.SaveChanges();
        }
        public int DeleteCategoryByName(string Name)
        {
            Category oldCategory = Context.Categories.FirstOrDefault(C => C.Name == Name);


            if (oldCategory != null)
            {
                Context.Categories.Remove(oldCategory);
                return Context.SaveChanges();
            }
            return Context.SaveChanges();
        }


    }

}
