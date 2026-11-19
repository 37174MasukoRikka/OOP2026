using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Data;
using SelfOrderSystem.Models;
using SelfOrderSystem.ViewModels;

namespace SelfOrderSystem.Controllers;

// スタッフのログインとログアウトを担当 
public class AccountController : Controller {
    private readonly AppDbContext _db;
    private readonly IPasswordHasher<StaffUser> _hasher;

    public AccountController(AppDbContext db, IPasswordHasher<StaffUser> hasher) {
        _db = db;
        _hasher = hasher;
    }
    [HttpGet, AllowAnonymous]
    public IActionResult Login(string? returnUrl = null) {
        return View(new StaffLoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(StaffLoginViewModel model) {
        if (!ModelState.IsValid) return View(model);

        // ユーザー名でDBを検索 
        var user = await _db.StaffUsers
            .SingleOrDefaultAsync(u => u.UserName == model.UserName);

        // 入力されたパスワードとハッシュを照合 
        var valid = user != null && _hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) != PasswordVerificationResult.Failed;
        if (!valid) {
            ModelState.AddModelError("", "ユーザー名またはパスワードが違います");
            return View(model);
        }

        // ログイン者のID・名前・権限を登録 
        var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, user!.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role)
        };
        var identity = new ClaimsIdentity(claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        // 認証Cookieをブラウザへ発行 
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        // 同じサイト内のページへ戻す 
        if (Url.IsLocalUrl(model.ReturnUrl))
            return LocalRedirect(model.ReturnUrl);
        return RedirectToAction("Index", "Staff");
    }
    // POST でログアウトする 
    [HttpPost, Authorize, ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout() {
        await HttpContext.SignOutAsync(
        CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction(nameof(Login));
    }
    // ログイン済みでも権限不足なら表示 
    [HttpGet, AllowAnonymous]
    public IActionResult Denied() {
        return Content("アクセス権がありません");
    }
}