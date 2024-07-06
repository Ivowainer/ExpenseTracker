using ExpenseTracker.DTOs;
using ExpenseTracker.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExpenseTracker.Repositories;

public class CategoryRepository(MongoDbAccess mongoDbAccess) : ICategoryRepository
{
    private readonly IMongoCollection<CategoryModel> _categoriesCollection = mongoDbAccess.GetDatabase().GetCollection<CategoryModel>(mongoDbAccess._settings.CategoryCollectionName);

    public async Task<List<CategoryModel>> GetCategories() =>
        await _categoriesCollection.Find(_ => true).ToListAsync();

    public async Task<CategoryModel> GetCategory(string id) =>
        await _categoriesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateCategory(CategoryModel category) =>
        await _categoriesCollection.InsertOneAsync(category);

    public async Task UpdateCategory(string id, CategoryModel category) =>
        await _categoriesCollection.ReplaceOneAsync(x => x.Id == id, category);
}