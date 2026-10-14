using SelfOrderSystem.Models;

namespace SelfOrderSystem.ViewModels;

public class MenuViewModel {
    public List<Category> Categories { get; set; } = new();  //カテゴリ一覧
    public List<Product> Products { get; set; } = new();  //商品一覧
    public int? SelectedCategoryId { get; set; }  //選択中カテゴリ
    public int CartItemCount { get; set; }       // カート内の合計数量（種類数ではない） 
    public decimal CartTotal { get; set; }       // カート合計金額
}

