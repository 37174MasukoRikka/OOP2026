using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Data;
using SelfOrderSystem.ViewModels;
using SelfOrderSystem.Services;

namespace SelfOrderSystem.Controllers;
public class MenuController : Controller {

    private readonly AppDbContext _db;     // DBへ問い合わせるためのフィールド 
    private readonly CartService _cart;    // Session上のカート操作用 

    // ASP.NET Coreから必要なAppDbContextとCarServiceを受け取る
    public MenuController(AppDbContext db, CartService cart) {
        _db = db;
        _cart = cart;
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

        var cartItems = _cart.GetItems();   // Sessionからカートを取得

        var vm = new MenuViewModel {
            Categories = categories,
            Products = products,
            SelectedCategoryId = categoryId,
            CartItemCount = cartItems.Sum(x => x.Quantity),   // 商品数量の合計
            CartTotal = cartItems.Sum(x => x.LineTotal),      // 小計の合計 
        };

        return View(vm);   //ViewModelをViewへ渡す
    }

}

