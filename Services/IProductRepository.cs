using Mobi__Shop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mobi__Shop.Services
{
    public interface IProductRepository
    {
        int AddNewProduct(ProductViewModel productViewModel);
        Task<int> DeleteProductById(int id);
        Task<int> DeleteProductByName(string Name);
        int Edit(int id, ProductViewModel productViewModel);
        List<ProductViewModel> FilterProductsWithCategoryName(string CategoryName);
        List<Product> GetAll();
        ProductViewModel GetByName(string Name);
        ProductViewModel GetProductByID(int Id);
        List<ProductViewModel> GetProductsByBrand(string BrandName);
        List<ProductViewModel> GetProductsByProductionYear(int ProductionYear);
        List<ProductViewModel> GetProductsOutOfStock();
        List<ProductViewModel> GetProductsWithStock();
        ProductViewModel SearchWithPartOfName(string Name);
    }
}