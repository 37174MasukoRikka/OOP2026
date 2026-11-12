using Microsoft.EntityFrameworkCore;       // EF Coreの非同期検索 
using SelfOrderSystem.Data;                 // AppDbContext 
using SelfOrderSystem.Models;               // ProductとOrder 
using Microsoft.AspNetCore.SignalR;
using SelfOrderSystem.Hubs;

namespace SelfOrderSystem.Services;

public class OrderService : IOrderService {

    private readonly AppDbContext _db;      // DB操作に使うフィールド 
    private readonly IHubContext<StaffOrdersHub> _hubContext; // 通知 
    private readonly ILogger<OrderService> _logger; // ログ

    //コンストラクタ
    public OrderService(AppDbContext db,
                        IHubContext<StaffOrdersHub> hubContext,
                        ILogger<OrderService> logger)    // DIからDbContextを受け取る 
    {
        _db = db;                     // DIでDBを受け取る 
        _hubContext = hubContext;     // DIでHubを受け取る 
        _logger = logger;             // DIでログを受け取る 
    }

    public async Task<PlaceOrderResult> PlaceAsync(List<CartItem> cartItems, int tableNumber) {
        var result = new PlaceOrderResult(); // 注文結果とエラーをまとめる 

        if (cartItems.Count == 0)           // カートが空なら中止 
        {
            result.Errors.Add("カートが空です");
            return result;
        }

        if (tableNumber < 1 || tableNumber > 999) // テーブル番号の範囲を確認 
        {
            result.Errors.Add("テーブル番号は1～999にしてください");
            return result;
        }

        var ids = cartItems.Select(x => x.ProductId)
            .Distinct().ToList();          // 商品IDの重複を除く 

        var products = await _db.Products.AsNoTracking()
            .Where(p => ids.Contains(p.Id) && p.IsActive)
            .ToDictionaryAsync(p => p.Id); // 商品IDをキーとする辞書で取得

        foreach (var item in cartItems)    // カートの商品を1件ずつ確認 
       {
            if (!products.TryGetValue(item.ProductId, out var product)) {
                result.Errors.Add("注文できない商品があります");
                continue;                   // 次の商品へ進む 
            }

            if (product.IsSoldOut)          // 売り切れを確認 
                result.Errors.Add($"{product.Name}は売り切れです");

            if (item.Quantity < 1 || item.Quantity > 99)
                result.Errors.Add("数量は1～99にしてください");

            if (product.Price != item.UnitPrice) // 追加後の価格変更を確認 
                result.Errors.Add($"{product.Name}の価格が変更されました");
        }

        if (result.Errors.Count > 0)       // エラーが1つでもあれば 
            return result;                // 保存せずに結果を返す
        var order = new Order             // 1件の注文全体を作る 
      {
            TableNumber = tableNumber,    // 画面から受け取った番号 
            OrderedAtUtc = DateTimeOffset.UtcNow, // 注文時刻 
            Status = OrderStatus.New       // 新規注文 
        };

        foreach (var item in cartItems)   // 商品ごとに明細を作る 
        {
            var product = products[item.ProductId]; // 確認済みの商品 
            order.Items.Add(new OrderItem {
                ProductId = product.Id,   // 注文した商品ID 
                Quantity = item.Quantity, // 注文数 
                UnitPrice = product.Price // DBで確認した単価 
            });
        }

        _db.Orders.Add(order);             // 注文と明細を保存対象に 

        await _db.SaveChangesAsync();      // SQL Serverの保存完了を待つ 
        result.PublicId = order.PublicId; // 完了画面で使うID 

        try {
            // 店舗画面へ更新の合図を送る
            await _hubContext.Clients.All.SendAsync("OrdersChanged");
        }
        catch (Exception ex) {
            // 通知失敗でも保存済みの注文は成功として扱う
            _logger.LogWarning(ex, "注文一覧への通知に失敗");
        }
        return result;  // 成功結果を返す 
    }
}