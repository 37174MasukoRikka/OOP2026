using Microsoft.AspNetCore.Mvc;
using MvcBasicSample.Models;


namespace MvcBasicSample.Controllers;

//URLのHelloに対応する要求を受け取るController
public class HelloController : Controller {

    // ../Hello/Index で呼び出されるAction
    public IActionResult Index() {
        //商品１件のオブジェクトを作る
        var products = new List<Product> {
            new Product {
                Name = "ハンバーガー",
                Price = 500
            },
            new Product {
                Name = "紅茶",
                Price = 450
            }          
        };

        return View(products);
    }
}

