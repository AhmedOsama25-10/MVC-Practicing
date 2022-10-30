using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Mobi__Shop.Models;
using Mobi_Shop.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext Context;
        private readonly IWebHostEnvironment HostEnvironment;

        public ProductRepository(AppDbContext _Context, IWebHostEnvironment _HostEnvironment)
        {
            Context = _Context;
            HostEnvironment = _HostEnvironment;
        }
        public List<Product> GetAll()
        {
            return Context.Products.ToList();
        }
        public ProductViewModel GetByName(string Name)
        {
            Product p = Context.Products.FirstOrDefault(P => P.Name == Name);
            if (p!=null)
            {
                ProductViewModel productViewModel = new ProductViewModel();

                productViewModel.BrandName = p.BrandName;
                productViewModel.CategotyID = p.CategoryID;
                productViewModel.ImgPath = p.Image;
                productViewModel.Name = p.Name;
                productViewModel.Price = p.Price;
                productViewModel.ProductionYear = p.ProductionYear;
                productViewModel.Stock = p.Stock;

                return productViewModel;
            }
            return new ProductViewModel();
            
        }
        public List<ProductViewModel> GetProductsByBrand(string BrandName)
        {
            List<Product> p = Context.Products.Where(P => P.BrandName == BrandName).ToList();
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
        public List<ProductViewModel> GetProductsByProductionYear(int ProductionYear)
        {
            List<Product> p = Context.Products.Where(P => P.ProductionYear.Year == ProductionYear).ToList();
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
            public List<ProductViewModel> GetProductsWithStock()
        {
            List<Product> p = Context.Products.Where(P => P.Stock > 0).ToList();
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
        public List<ProductViewModel> GetProductsOutOfStock()
        {
            List<Product> p = Context.Products.Where(P => P.Stock == 0).ToList();
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
        public ProductViewModel GetProductByID(int Id)
        {

            Product p =  Context.Products.FirstOrDefault(P => P.ID == Id);
            if (p !=null)
            {
                ProductViewModel productViewModel = new ProductViewModel();

                productViewModel.BrandName = p.BrandName;
                productViewModel.CategotyID = p.CategoryID;
                productViewModel.ImgPath = p.Image;
                productViewModel.Name = p.Name;
                productViewModel.Price = p.Price;
                productViewModel.ProductionYear = p.ProductionYear;
                productViewModel.Stock = p.Stock;

                return productViewModel;

            }
            return new ProductViewModel();


        }
        public List<ProductViewModel> FilterProductsWithCategoryName(string CategoryName)
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
        public ProductViewModel SearchWithPartOfName(string Name)
        {
            Product p = Context.Products.FirstOrDefault(p => p.Name.Contains(Name));
            if (p != null)
            {
                ProductViewModel productViewModel = new ProductViewModel();

                productViewModel.BrandName = p.BrandName;
                productViewModel.CategotyID = p.CategoryID;
                productViewModel.ImgPath = p.Image;
                productViewModel.Name = p.Name;
                productViewModel.Price = p.Price;
                productViewModel.ProductionYear = p.ProductionYear;
                productViewModel.Stock = p.Stock;

                return productViewModel;
            }
            return new ProductViewModel();
        }
        public async Task<int> DeleteProductById(int id)
        {
            Product p = Context.Products.FirstOrDefault(P => P.ID == id);

            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", p.Image);


            if (p != null)
            {
                Context.Products.Remove(p);
                int R = await Context.SaveChangesAsync();
                if (R > 0)
                {
                    if (File.Exists(CurrentImage))
                    {
                        File.Delete(CurrentImage);
                    }
                }
            }
            return Context.SaveChanges();
        }
        public async Task<int> DeleteProductByName(string Name)
        {
            Product p = Context.Products.FirstOrDefault(P => P.Name == Name);
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", p.Image);


            if (p != null)
            {
                Context.Products.Remove(p);
                int R = await Context.SaveChangesAsync();
                if (R > 0)
                {
                    if (File.Exists(CurrentImage))
                    {
                        File.Delete(CurrentImage);
                    }
                }
            }
            return Context.SaveChanges();
        }
        public int AddNewProduct(ProductViewModel productViewModel)
        {
            string UniqeFileName = null;
            if (productViewModel.Image != null)
            {
                string UploadsFolder = Path.Combine(HostEnvironment.WebRootPath, "images");
                UniqeFileName = Guid.NewGuid().ToString() + "_" + productViewModel.Image.FileName;
                string FilePath = Path.Combine(UploadsFolder, UniqeFileName);
                productViewModel.Image.CopyTo(new FileStream(FilePath, FileMode.Create));
            }
            Product p = new Product();
            p.Name = productViewModel.Name;
            p.BrandName = productViewModel.BrandName;
            p.Price = productViewModel.Price;
            p.ProductionYear = productViewModel.ProductionYear;
            p.Stock = productViewModel.Stock;
            p.CategoryID = productViewModel.CategotyID;
            p.Image = UniqeFileName;
            Context.Products.Add(p);
            return Context.SaveChanges();
        }
        public int Edit(int id, ProductViewModel productViewModel)
        {
            Product p = Context.Products.FirstOrDefault(P => P.ID == id);
            if (p != null)
            {
               

                p.Name = productViewModel.Name;
                p.BrandName = productViewModel.BrandName;
                p.Price = productViewModel.Price;
                p.ProductionYear = productViewModel.ProductionYear;
                p.Stock = productViewModel.Stock;
                p.CategoryID = productViewModel.CategotyID;
                
                Context.SaveChanges();

            }
                return Context.SaveChanges();
            

        }

    }
}
