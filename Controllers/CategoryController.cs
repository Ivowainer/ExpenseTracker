
using ExpenseTracker.DTOs;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[Route("api/category")]
public class CategoryController(ICategoryService categoryService) : Controller
{
    [HttpGet]
    public async Task<List<CategoryModel>> GetCategories() =>
        await categoryService.GetCategories();

    [HttpGet("{id}")]
    public async Task<CategoryModel> GetCateogry(string id) =>
        await categoryService.GetCategory(id);

    [HttpPost]
    public async Task CreateCategory([FromBody] CategoryDto category) =>
        await categoryService.CreateCategory(category);
}