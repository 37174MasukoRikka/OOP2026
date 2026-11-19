using System.ComponentModel.DataAnnotations;

namespace SelfOrderSystem.ViewModels;

// ログイン画面の入力値 
public class StaffLoginViewModel {
    [Required(ErrorMessage = "ユーザー名を入力してください")]
    public string UserName { get; set; } = "";

    [Required(ErrorMessage = "パスワードを入力してください")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    // ログイン前に開こうとしたページ 
    public string? ReturnUrl { get; set; }
}