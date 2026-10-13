using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Models;

namespace SelfOrderSystem.Data;
public class SeedData {
    public static async Task InitializeAsync(AppDbContext db) {
        if (await db.Categories.AnyAsync()) {
            return;  // 登録済みなら終了 
        }

        //カテゴリーのデータ登録
        var meat = new Category { Name = "肉料理", SortOrder = 1 };
        var curry = new Category { Name = "カレー", SortOrder = 2 };
        var drink = new Category { Name = "ドリンク", SortOrder = 3 };

        db.Categories.AddRange(meat, curry, drink);
        await db.SaveChangesAsync();   // CategoryIdを確定 

        //商品のデータ登録
        db.Products.AddRange(
            new Product {
                CategoryId = meat.Id,
                Name = "上州牛ハンバーグ",
                Price = 1480m,
                Description = "鉄板で提供するハンバーグです"
            },
        new Product {
            CategoryId = meat.Id,
            Name = "グリルチキン",
            Price = 1280m,
            Description = "香ばしく焼き上げたチキンです"
        },
        new Product {
            CategoryId = curry.Id,
            Name = "ビーフカレー",
            Price = 980m,
            Description = "じっくり煮込んだビーフカレーです"
        },
        new Product {
            CategoryId = drink.Id,
            Name = "アイスコーヒー",
            Price = 380m,
            Description = "食後にもおすすめです"
        });

        await db.SaveChangesAsync();  // 商品を保存 
    }
}

