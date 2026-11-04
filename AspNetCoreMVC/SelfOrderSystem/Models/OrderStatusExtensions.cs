namespace SelfOrderSystem.Models;
public static class OrderStatusExtensions {
    public static string ToJapanese(this OrderStatus status) {
        return status switch {
            OrderStatus.New => "新規注文",
            OrderStatus.Accepted => "受付済み",
            OrderStatus.Cooking => "調理中",
            OrderStatus.Served => "提供済み",
            _ => "不明"
        };
    }

    public static string NextActionLabel(this OrderStatus status) {
        return status switch {
            OrderStatus.New => "受付する",
            OrderStatus.Accepted => "調理開始",
            OrderStatus.Cooking => "提供完了",
            _ => "完了"
        };
    }
}
