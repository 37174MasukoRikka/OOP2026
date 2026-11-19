using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Models;

namespace SelfOrderSystem.Data;

// 初期スタッフを1回だけ登録する 
public static class StaffAccountSeeder {
    public static async Task InitializeAsync(IServiceProvider services) {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        var hasher = scope.ServiceProvider
            .GetRequiredService<IPasswordHasher<StaffUser>>();

        // 既にスタッフがいれば追加しない 
        if (await db.StaffUsers.AnyAsync()) return;

        // 初期パスワードは設定から取得 
        var password = config["StaffAdmin:InitialPassword"];
        if (string.IsNullOrWhiteSpace(password) || password.Length < 12)
            throw new InvalidOperationException("StaffAdmin:InitialPasswordを12文字以上で設定してください");

        var user = new StaffUser { UserName = "staffadmin" };

        user.PasswordHash = hasher.HashPassword(user, password);
        db.StaffUsers.Add(user);

        await db.SaveChangesAsync();
    }
}