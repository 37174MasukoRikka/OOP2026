using SelfOrderSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace SelfOrderSystem.ViewModels;

public class CheckoutViewModel {
    [Display(Name = "テーブル番号")]
    [Range(1, 999, ErrorMessage = "1～999を入力してください")]
    public int TableNumber { get; set; }
    public List<CartItem> Items { get; set; } = new();
    public decimal Total => Items.Sum(x => x.LineTotal);
}
