using System.ComponentModel.DataAnnotations;

namespace SelfOrderSystem.Models {
    public class Category {
        public int Id { get; set; } //主キー
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty; //カテゴリー名
        public int SortOrder { get; set; }　 //表示順
        public List<Product> Products { get; set; } = new();  //所属商品
    }
}
