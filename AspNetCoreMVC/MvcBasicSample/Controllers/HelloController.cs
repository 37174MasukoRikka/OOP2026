using Microsoft.AspNetCore.Mvc;


namespace MvcBasicSample.Controllers;

//URLのHelloに対応する要求を受け取るController
public class HelloController : Controller{

    // ../Hello/Index で呼び出されるAction
    public IActionResult Index() {
        //Viewを使用せず文字列をHTTPの応答として返す
        //return Content("初めてのASP.NET Core");
        return View();
    }
}

