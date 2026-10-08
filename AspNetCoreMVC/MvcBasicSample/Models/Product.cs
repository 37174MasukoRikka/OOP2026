using System.ComponentModel.DataAnnotations;

namespace MvcBasicSample.Models;
//商品1件の名前と価格をまとめる
public class Product {
    public int Id { get; set; } //主キー

    [Required] //必須項目
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; } //円単位の価格
    public int Stock { get; set; }

}
