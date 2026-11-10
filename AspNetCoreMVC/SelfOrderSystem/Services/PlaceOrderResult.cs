namespace SelfOrderSystem.Services;

// 注文処理の結果をまとめる
public class PlaceOrderResult {
    public Guid? PublicId { get; set; }     // 成功した注文の公開ID 
    public List<string> Errors { get; set; } = new(); // 失敗時のメッセージ 
    public bool IsSuccess =>                // 成功かどうかを計算 
        PublicId.HasValue && Errors.Count == 0;

}
