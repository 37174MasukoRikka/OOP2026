using Microsoft.AspNetCore.Http;
using SelfOrderSystem.Models;

namespace SelfOrderSystem.Services;

public class CartService       // カート操作をまとめるクラス 
{
    private const string CartKey = "CART";                       // Sessionのキー 
    private readonly IHttpContextAccessor _httpContextAccessor;  // HttpContext取得用 

    public CartService(IHttpContextAccessor httpContextAccessor) // HttpContext取得用の仕組みを受け取る 
    {
        _httpContextAccessor = httpContextAccessor;
    }

    // 現在のHTTP要求にひも付くSessionを取り出す 
    private ISession Session => _httpContextAccessor.HttpContext?.Session
               ?? throw new InvalidOperationException("Sessionを取得できません");

    public List<CartItem> GetItems()    // Sessionからカートを取得 
    {
        return Session.GetObject<List<CartItem>>(CartKey)         // CARTをList<CartItem>へ戻す 
                                         ?? new List<CartItem>();
    }

    public void Add(Product product)     // 商品を1個追加 
    {
        var items = GetItems();
        var item = items.SingleOrDefault(x => x.ProductId == product.Id); // 同じ商品を探す 

        if (item == null) {
            items.Add(new CartItem {
                ProductId = product.Id,
                ProductName = product.Name,
                UnitPrice = product.Price,
                Quantity = 1
            });
        } else {
            item.Quantity++;      // 既存商品なら数量だけ1増やす 
        }

        Save(items);    // 変更後のカートをSessionへ保存 
    }

    public void SetQuantity(int productId, int quantity) {
        var items = GetItems();
        var item = items.SingleOrDefault(x => x.ProductId == productId);

        if (item == null) {
            return;
        }

        item.Quantity = Math.Clamp(quantity, 1, 99);              // 数量を1～99の範囲へ収める 
        Save(items);                                              // 変更後のカートをSessionへ保存 
    }

    public void Remove(int productId) {
        var items = GetItems();
        items.RemoveAll(x => x.ProductId == productId);         // 指定商品だけ削除する 
        Save(items);                                              // 変更後のカートをSessionへ保存 
    }

    public void Clear() {
        Session.Remove(CartKey);                                 // CARTキーを削除してカートを空にする 
    }

    private void Save(List<CartItem> items) {
        Session.SetObject(CartKey, items);                       // List<CartItem>をJSON化して保存 
    }
}


