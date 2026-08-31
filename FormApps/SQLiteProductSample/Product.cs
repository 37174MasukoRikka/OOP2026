using System.ComponentModel;

namespace SQLiteProductSample;

public class Product 
{
    //商品ID(自動採番)
    [DisplayName("ID")]
    public int Id { get; set; }

    //商品名
    [DisplayName("商品名")]
    public string Name { get; set; } = string.Empty;

    //商品価格
    [DisplayName("価格")]
    public int Price { get; set; }

}
