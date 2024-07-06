using ExpenseTracker.DTOs;
using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces;

public interface ICategoryService
{
    public Task<List<CategoryModel>> GetCategories();
    public Task<CategoryModel> GetCategory(string id);
    public Task CreateCategory(CategoryDto category);
    public Task UpdateCategory(string id, CategoryDto category);
}