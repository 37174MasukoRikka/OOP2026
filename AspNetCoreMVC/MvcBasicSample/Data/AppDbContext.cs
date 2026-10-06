using Microsoft.EntityFrameworkCore;
using MvcBasicSample.Models;

namespace MvcBasicSample.Data;
public class AppDbContext : DbContext {

    //Program.cs で登録した接続設定を受け取る
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { //受け取った設定を親クラスへ渡す
    }

    //ProductsテーブルをProduct型として問い合わせるためのプロパティ
    public DbSet<Product> Products => Set<Product>();

}

