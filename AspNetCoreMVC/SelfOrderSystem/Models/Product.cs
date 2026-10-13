using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelfOrderSystem.Models {
    public class Product {
        public int Id { get; set; }  //主キー
        public int CategoryId { get; set; }  //外部キー

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;  // 商品名

        [Column(TypeName = "decimal(10,0)")]
        public decimal Price { get; set; }  //価格

        [StringLength(500)]
        public string? Description { get; set; }  // 商品説明 

        [StringLength(300)]
        public string? ImagePath { get; set; }  // 商品画像パス

        public bool IsSoldOut { get; set; }  // 売り切れ 
        public bool IsActive { get; set; } = true;  // 表示対象 

        public Category? Category { get; set; }  // 所属カテゴリ
    }
}
