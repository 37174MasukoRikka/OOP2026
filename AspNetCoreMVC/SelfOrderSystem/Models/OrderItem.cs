using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelfOrderSystem.Models;

public class OrderItem {                // 注文に含まれる商品1行
    public int Id { get; set; }
    public int OrderId { get; set; }    // 親注文への外部キー 
    public int ProductId { get; set; }  // 商品への外部キー 
    [Range(1, 99)]
    public int Quantity { get; set; }　　　//数量
    [Column(TypeName = "decimal(10,0)")]
    public decimal UnitPrice { get; set; } // 注文時の確定単価 
    public Order? Order { get; set; }
    public Product? Product { get; set; }
    [NotMapped]
    public decimal LineTotal => UnitPrice * Quantity;
}
