using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Data;
using SelfOrderSystem.Services;

namespace SelfOrderSystem.Controllers;
public class CartController : Controller {
    private readonly AppDbContext _db;                          // 商品確認用 
    private readonly CartService _cart;                         // カート操作用 

    public CartController(AppDbContext db, CartService cart) {
        _db = db;
        _cart = cart;
    }

    public IActionResult Index() {
        return View(_cart.GetItems());  //Session のカート一覧をViewへ渡す
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(int productId)      // 商品IDを受け取る 
   {
        var product = await _db.Products.AsNoTracking()   // 読み取り専用 
            .SingleOrDefaultAsync(p => p.Id == productId && p.IsActive); // 利用可能な商品を1件取得 

        if (product == null) {
            return NotFound();                              // 該当商品がなければ404を返す 
        }

        if (product.IsSoldOut) {
            TempData["Error"] = "この商品は売り切れです";   // 次の画面へエラーを渡す 
            return RedirectToAction("Index", "Menu");
        }

        _cart.Add(product);                                 // カート変更はCartServiceへ任せる 
        return RedirectToAction("Index", "Menu");
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(int productId, int quantity) {
        _cart.SetQuantity(productId, quantity);
        // 指定商品の数量を変更 
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int productId) {
        _cart.Remove(productId);
        // 指定商品をカートから削除 
        return RedirectToAction(nameof(Index));
    }
}

