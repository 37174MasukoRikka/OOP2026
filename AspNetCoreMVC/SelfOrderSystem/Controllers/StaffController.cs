using Microsoft.AspNetCore.Mvc;      // Controllerを使用 
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore; // EF Coreの非同期処理を使用 
using Microsoft.Extensions.Logging;
using SelfOrderSystem.Data;          // AppDbContextを使用 
using SelfOrderSystem.Hubs;
using SelfOrderSystem.Models; // OrderStatusを使用 
using SelfOrderSystem.Services;


namespace SelfOrderSystem.Controllers;

public class StaffController : Controller {
    private readonly AppDbContext _db; // DBへの接続を担当 
    private readonly IHubContext<StaffOrdersHub> _hubContext; // 通知 
    private readonly ILogger<StaffController> _logger;

    public StaffController(AppDbContext db,
                         IHubContext<StaffOrdersHub> hubContext,
                         ILogger<StaffController> logger) {
        _db = db; // 既存のDB操作 
        _hubContext = hubContext; // SignalRで通知 
        _logger = logger; // 通知エラーを記録 
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

    // 店員のボタン操作で注文状態を1段階進める 
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Advance(int id) {
        // 注文IDから対象の注文を検索 
        var order = await _db.Orders.FindAsync(id);
        if (order == null) {
            return NotFound(); // 該当する注文がない 
        }

        // 現在の状態に応じて次の状態へ変更 
        if (order.Status == OrderStatus.New) {
            order.Status = OrderStatus.Accepted;
        } else if (order.Status == OrderStatus.Accepted) {
            order.Status = OrderStatus.Cooking;
        } else if (order.Status == OrderStatus.Cooking) {
            order.Status = OrderStatus.Served;
        } else {
            // 提供済みの注文は変更しない 
            return RedirectToAction(nameof(Index));
        }

        await _db.SaveChangesAsync(); // 変更をDBへ保存 

        try {
            // この注文を見ているお客様だけに通知 
            await _hubContext.Clients
                .Group($"order-{order.PublicId:N}")
                .SendAsync("OrderStatusChanged");

            // 他の店舗画面にも一覧変更を通知 
            await _hubContext.Clients.All.SendAsync("OrdersChanged");
        }
        catch (Exception ex) {
            // 保存した注文状態は取り消さない 
            _logger.LogWarning(ex, "状態更新の通知に失敗");
        }

        return RedirectToAction(nameof(Index)); // 一覧へ戻る 
    }
}