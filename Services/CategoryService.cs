using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using MongoDB.Bson;

namespace ExpenseTracker.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    
    public async Task<List<CategoryModel>> GetCategories()
    {
        return await categoryRepository.GetCategories();
    }

    public async Task<CategoryModel> GetCategory(string id)
    {
        if (!ObjectId.TryParse(id, out _))
            throw new ArgumentException("Invalid ID format", nameof(id));

        var category = await categoryRepository.GetCategory(id);

        if (category == null)
            throw new ArgumentException("The category does not exist");
        
        return category;
    }

    public async Task CreateCategory(CategoryModel category) {
        if (category.Title == null)
            throw new ArgumentException("Invalid Category Title");
        
        await categoryRepository.CreateCategory(category);
    }

    public async Task UpdateCategory(string id, CategoryModel category)
    {
        if (!ObjectId.TryParse(id, out _))
            throw new ArgumentException("Invalid ID format", nameof(id));

        await categoryRepository.UpdateCategory(id, category);
    }
}