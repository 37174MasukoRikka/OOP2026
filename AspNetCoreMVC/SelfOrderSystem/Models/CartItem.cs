namespace SelfOrderSystem.Models;

// カート内の1商品を表す一時データ
public class CartItem {
    public int ProductId { get; set; }                           // 商品ID 
    public string ProductName { get; set; } = string.Empty;      // 商品名 
    public decimal UnitPrice { get; set; }                       // 単価 
    public int Quantity { get; set; }                            // 数量 
    public decimal LineTotal => UnitPrice * Quantity;            // 小計 
}