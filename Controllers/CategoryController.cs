
using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[Route("api/category")]
public class CategoryController(ICategoryService categoryService) : Controller
{

    [HttpPost]
    public async Task CreateCategory([FromBody] CategoryModel category)
    {
        await categoryService.CreateCategory(category);
    }
}