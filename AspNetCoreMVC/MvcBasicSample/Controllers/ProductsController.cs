using Microsoft.AspNetCore.Mvc;         // MVCの機能を使用 
using Microsoft.EntityFrameworkCore;    // ToListAsyncを使用 
using MvcBasicSample.Data;              // AppDbContextを使用

namespace MvcBasicSample.Controllers;

public class ProductsController : Controller {
    private readonly AppDbContext _db;  // DBへ問い合わせるためのフィールド 

    // ASP.NET Coreから必要なAppDbContextを受け取る
    public ProductsController(AppDbContext db) {
        _db = db;
    }

    // /Products/Indexで商品一覧を取得する(非同期メソッド)
    public async Task<IActionResult> Index() {

        //Idの昇順で取得し結果をList<Product>にする
        var products = await _db.Products.Where(product => product.Price >= 500).OrderBy(product => product.Price).ToListAsync();

        return View(products);
    }
}
