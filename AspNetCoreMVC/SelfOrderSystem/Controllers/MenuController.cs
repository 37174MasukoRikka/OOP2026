using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Data;
using SelfOrderSystem.ViewModels;

namespace SelfOrderSystem.Controllers;
public class MenuController : Controller{
    private readonly AppDbContext _db;  // DBへ問い合わせるためのフィールド 

    // ASP.NET Coreから必要なAppDbContextを受け取る
    public MenuController(AppDbContext db) {
        _db = db;  //DIで受け取る
    }

    public async Task<IActionResult> Index(int? categoryId) {

        var categories = await _db.Categories
            .AsNoTracking()
            .OrderBy(c => c.SortOrder)
            .ToListAsync();

        var query = _db.Products
            .AsNoTracking()
            .Include(p => p.Category)
            .Where(p => p.IsActive);

        if (categoryId.HasValue) {
            query = query.Where(p => p.CategoryId == categoryId.Value);
        }

        var products = await query
            .OrderBy(p => p.Category!.SortOrder)
            .ThenBy(p => p.Name)
            .ToListAsync();

        var vm = new MenuViewModel {
            Categories = categories,
            Products = products,
            SelectedCategoryId = categoryId
        };

        return View(vm);   //ViewModelをViewへ渡す
    }

}

