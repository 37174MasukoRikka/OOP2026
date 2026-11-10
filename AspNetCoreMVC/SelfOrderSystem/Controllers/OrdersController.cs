using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Data;
using SelfOrderSystem.Models;
using SelfOrderSystem.Services;
using SelfOrderSystem.ViewModels;
using System.Numerics;

namespace SelfOrderSystem.Controllers;

public class OrdersController : Controller {
    private readonly AppDbContext _db;      // 商品と注文のDB操作 
    private readonly CartService _cart;    // Session内のカート操作 
    private readonly IOrderService _orderService; //注文の検証と保存を担当するService

    public OrdersController(AppDbContext db, CartService cart, IOrderService orderService) {
        _db = db;
        _cart = cart;
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult Checkout() {
        var items = _cart.GetItems();     // Sessionからカートを読む 
        if (items.Count == 0) {
            return RedirectToAction("Index", "Menu");
        }

        return View(new CheckoutViewModel { Items = items });
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Place(CheckoutViewModel model) {
        var cartItems = _cart.GetItems(); // Sessionを再取得 

        //if (cartItems.Count == 0)
        //    ModelState.AddModelError("", "カートが空です");

        //var ids = cartItems.Select(x => x.ProductId).Distinct().ToList();
        //var products = await _db.Products.AsNoTracking()
        //    .Where(p => ids.Contains(p.Id) && p.IsActive)
        //    .ToDictionaryAsync(p => p.Id); // 現在のDBから商品情報を取得 

        //foreach (var item in cartItems) {
        //    if (!products.TryGetValue(item.ProductId, out var product)) {
        //        ModelState.AddModelError("", "注文できない商品があります");
        //        continue;
        //    }
        //    if (product.IsSoldOut)
        //        ModelState.AddModelError("", $"{product.Name}は売り切れです");
        //    if (item.Quantity < 1 || item.Quantity > 99)
        //        ModelState.AddModelError("", "数量は1～99にしてください");
        //    if (product.Price != item.UnitPrice)
        //        ModelState.AddModelError("", $"{product.Name}の価格が変更されました");
        //}

        if (!ModelState.IsValid) {
            model.Items = cartItems;     // 再表示用の一覧を戻す 
            return View("Checkout", model);
        }

        //注文処理をServiceへ依頼
        var result = await _orderService.PlaceAsync(cartItems, model.TableNumber);

        //エラーかチェック
        if (!result.IsSuccess) {
            foreach(var error in result.Errors) {
                ModelState.AddModelError("", error);  //エラーを画面表示する
            }
            model.Items = cartItems;
            return View("Checkout", model);
        }

        _cart.Clear();                  // 保存成功後にカートを空にする 
        return RedirectToAction(nameof(Complete),
            new { id = result.PublicId });
    }

    [HttpGet]
    public async Task<IActionResult> Complete(Guid id) {
        var order = await LoadPublicOrderAsync(id);
        return order == null ? NotFound() : View(order);
    }

    [HttpGet]
    public async Task<IActionResult> Status(Guid id) {
        var order = await LoadPublicOrderAsync(id);
        return order == null ? NotFound() : View(order);
    }

    private Task<Order?> LoadPublicOrderAsync(Guid publicId) {
        return _db.Orders.AsNoTracking()
            .Include(o => o.Items)
            .ThenInclude(i => i.Product)
            .SingleOrDefaultAsync(o => o.PublicId == publicId);
    }
}
