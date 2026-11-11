using Microsoft.AspNetCore.Mvc;      // Controllerを使用 
using Microsoft.EntityFrameworkCore; // EF Coreの非同期処理を使用 
using SelfOrderSystem.Data;          // AppDbContextを使用 

namespace SelfOrderSystem.Controllers;

public class StaffController : Controller {
    private readonly AppDbContext _db; // DBへの接続を担当 

    public StaffController(AppDbContext db) {
        _db = db; // DIで受け取ったものを保存 
    }

    [HttpGet] // 注文一覧を表示するGETリクエスト 
    public async Task<IActionResult> Index() {
        var orders = await _db.Orders
                           .AsNoTracking()                // 表示専用なので追跡しない 
                           .Include(o => o.Items)         // 注文明細を一緒に取得 
                           .ThenInclude(i => i.Product)   // 明細に対応する商品を取得 
                           .OrderByDescending(o => o.OrderedAtUtc) // 新しい順 
                           .Take(50)                     // 最大50件 
                           .ToListAsync();               // 注文一覧を取得 

        return View(orders); // Views/Staff/Index.cshtmlに渡す 
    }
}