using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    //売り上げ集計クラス
    public class SalesCounter {
        private readonly List<Sale> _sales;

        //コンストラクター
        public SalesCounter(List<Sale>sales) {
            _sales = sales;
                
        }

        //店舗別売り上げを求める
        public Dictionary<string, int> GetPerStoreSales() {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (var sale in _sales) {
                //既に店舗名が辞書のキーに登録されているか？
                if (dict.ContainsKey(sale.ShopName))     
                    //登録されている場合
                    dict[sale.ShopName] += sale.Amount;　//売上を足しこみ
                else
                    //未登録の場合
                    dict[sale.ShopName] = sale.Amount;  //新規に売上を登録
            }
            return dict;
        }
    }
}
