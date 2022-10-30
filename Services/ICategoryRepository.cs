using Mobi__Shop.Models;
using System.Collections.Generic;

namespace Mobi__Shop.Services
{
    public interface ICategoryRepository
    {
        int AddNewCategory(CategoryViewModel categoryViewModel);
        int DeleteCategoryByID(int id);
        int DeleteCategoryByName(string Name);
        List<CategoryViewModel> GetAllCategoryNames();
        CategoryViewModel GetCategoryById(int id);
        List<ProductViewModel> GetProductsWithCategoryID(int id);
        List<ProductViewModel> GetProductsWithCategoryName(string CategoryName);
        int UpdateCategoryByID(int id, CategoryViewModel categoryViewModel);
        int UpdateCategoryByName(string Name, CategoryViewModel categoryViewModel);
    }
}