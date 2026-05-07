using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    //売り上げ集計クラス
    public class SalesCounter {
        private readonly IEnumerable<Sale> _sales;

        //コンストラクター
        public SalesCounter(string filePath) {
            _sales = ReadSales(filePath);
                
        }

        public IEnumerable<Sale> ReadSales(string filePath) {
            List<Sale> sales = new List<Sale>();  //リスト
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines) {
                string[] items = line.Split(','); //カンマ区切りで分割
                Sale sale = new Sale {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2])
                };
                sales.Add(sale);
            }
            return sales;
        }

        //店舗別売り上げを求める
        public IDictionary<string, int> GetPerStoreSales() {
            var dict = new SortedDictionary<string, int>();

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
